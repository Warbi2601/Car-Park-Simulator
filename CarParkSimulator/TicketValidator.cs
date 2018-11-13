using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    public class TicketValidator
    {
        private string message;

        ActiveTickets activeTickets;
        CarPark carPark;
        private Ticket insertedTicket;

        public TicketValidator(ActiveTickets activeTickets)
        {
            this.activeTickets = activeTickets;
        }

        public void AssignCarPark(CarPark carPark)
        {
            this.carPark = carPark;
        }

        public void CarArrived()
        {
            message = "Please insert your ticket";
        }

        public void TicketEntered(Ticket selectedTicket)
        {
            message = "Thank You, drive safely";
            activeTickets.RemoveTicket(selectedTicket);
            carPark.TicketValidated();
            
        }

        public void ClearMessage()
        {
            message = "";
        }

        public string GetMessage()
        {
            return message;
        }

        public void InsertTicket(Ticket ticket)
        {
            this.insertedTicket = ticket;
        }

        public Ticket GetInsertedTicket()
        {
            return this.insertedTicket;
        }
    }
}
