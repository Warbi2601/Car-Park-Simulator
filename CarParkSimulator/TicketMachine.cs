using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    public class TicketMachine
    {
        private string message;
        ActiveTickets activeTickets;
        CarPark carPark;

        public TicketMachine(ActiveTickets activeTickets)
        {
            this.activeTickets = activeTickets;
        }

        public void AssignCarPark(CarPark carPark)
        {
            this.carPark = carPark;
        }

        public void CarArrived()
        {
            message = "Please press to get a ticket";
        }

        public void PrintTicket()
        {
            message = "Thank You, enjoy your stay.";
            activeTickets.AddTicket();
            carPark.TicketDispensed();
        }

        public void ClearMessage()
        {
            message = "";
        }

        public string GetMessage()
        {
            return message;
        }

    }
}
