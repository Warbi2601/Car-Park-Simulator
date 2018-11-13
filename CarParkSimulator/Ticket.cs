using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    public class Ticket
    {
        private bool paid = false;
        int ID;
        private DateTime dt;

        public int getID()
        {
            return ID;
        }

        public Ticket()
        {
            dt = DateTime.Now;
            Random rnd = new Random();
            ID = rnd.Next(100000, 999999);
        }

        public bool IsPaid()
        {
            return paid;
        }

        public void SetPaid(bool paid)
        {
            this.paid = paid;
        }

        public DateTime GetStartTime()
        {
            return this.dt;
        }

    }
}
