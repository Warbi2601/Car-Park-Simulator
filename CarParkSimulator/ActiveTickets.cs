using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    public class ActiveTickets
    {
        List<Ticket> activeTickets = new List<Ticket>();
        
        public List<Ticket> GetTickets()
        {
            return activeTickets;
            
        }

        public void AddTicket()
        {
            activeTickets.Add(new Ticket());
        }

        public void RemoveTicket(Ticket selectedTicket)
        {
            activeTickets.Remove(selectedTicket);
        }

        public Ticket GetTicket(string id)
        {
            Ticket ticket = null;

            int ticketID;
            if (int.TryParse(id, out ticketID))
            {
                foreach (Ticket t in this.GetTickets())
                {
                    if (t.getID() == ticketID)
                    {
                        ticket = t;
                        break;
                    }
                }
            }
            return ticket;
        }

    }
}