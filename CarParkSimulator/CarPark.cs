using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    public class CarPark
    {
        private int currentSpaces = 5;
        private int maxSpace = 5;
    
        public int getMaxSpaces()
        {
            return maxSpace;
        }

        Barrier entryBarrier;
        Barrier exitBarrier;
        TicketMachine ticketMachine;
        TicketValidator ticketValidator;
        FullSign fullSign;
        private PaymentMachine paymentMachine;

        List<SpaceSensor> spaces = new List<SpaceSensor>();

        public CarPark(TicketMachine ticketMachine, TicketValidator ticketValidator, FullSign fullSign, Barrier entryBarrier, Barrier exitBarrier, int maxspaces)
        {
            this.currentSpaces = maxspaces;
            this.maxSpace = maxspaces;

            this.entryBarrier = entryBarrier;
            this.exitBarrier = exitBarrier;
            this.ticketMachine = ticketMachine;
            this.ticketValidator = ticketValidator;
            this.fullSign = fullSign;
            this.paymentMachine = new PaymentMachine();

            for (int i = 0; i < maxSpace; i++)
            {
                spaces.Add(new SpaceSensor(this, i));
            }
        }

        public void CarArrivedAtEntrance()
        {
            ticketMachine.CarArrived();
        }

        public PaymentMachine GetPaymentMachine()
        {
            return this.paymentMachine;
        }

        public void TicketDispensed()
        {
            entryBarrier.Raise();
            
        }

        public void CarEnteredCarPark()
        {
            ticketMachine.ClearMessage();
            entryBarrier.Lower();
            currentSpaces--;
            fullSign.SetLit(this.IsFull());
        }

        public void CarArrivedAtExit()
        {
            ticketValidator.CarArrived();
        }

        public void TicketValidated()
        {
            exitBarrier.Raise();  
        }

        public void CarExitedCarPark()
        {
            ticketValidator.ClearMessage();
            exitBarrier.Lower();
            currentSpaces++;
            fullSign.SetLit(this.IsFull());
        }

        public bool IsFull()
        {
            return (currentSpaces <= 0);
        }

        public bool IsEmpty()
        {
            return (currentSpaces == maxSpace);
        }

        public bool HasSpace()
        {
            return (currentSpaces > 0);
        }

        public int GetCurrentSpaces()
        {
            return currentSpaces;
        }

        public void carParksInRandomSpace()
        {
            List<SpaceSensor> freeSpaces = getAvailableSpaces();
            Random rnd = new Random();
            freeSpaces[rnd.Next(0, freeSpaces.Count - 1)].CarDetected();
        }

        public List<SpaceSensor> getAvailableSpaces()
        {
            List<SpaceSensor> sensors = new List<SpaceSensor>();
            foreach(SpaceSensor s in spaces)
            {
                if (!s.IsCarOnSensor()) sensors.Add(s);
            }
            return sensors;
        }

        public List<SpaceSensor> getTakenSpaces()
        {
            List<SpaceSensor> sensors = new List<SpaceSensor>();
            foreach (SpaceSensor s in spaces)
            {
                if (s.IsCarOnSensor()) sensors.Add(s);
            }
            return sensors;
        }

        public void carLeavesRandomSpace()
        {
            List<SpaceSensor> takenSpaces = getTakenSpaces();
            Random rnd = new Random();
            takenSpaces[rnd.Next(0, takenSpaces.Count - 1)].CarLeftSensor();
        }
    }
}
