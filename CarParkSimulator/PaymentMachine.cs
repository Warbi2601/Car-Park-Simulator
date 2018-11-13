using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkSimulator
{
    public class PaymentMachine
    {
        private Ticket currentTicket;
        private decimal cost;
        private decimal balance;
        private const decimal hourlyRate = 1.20M;

        public PaymentMachine()
        {

        }

        public void InsertTicket(Ticket ticket)
        {
            this.currentTicket = ticket;
        }

        public Ticket GetCurrentTicket()
        {
            return this.currentTicket;
        }

        public decimal GetCost()
        {
            return this.cost;
        }

        public decimal CalculateCost()
        {
            int minutes = DateTime.Now.Subtract(this.GetCurrentTicket().GetStartTime()).Minutes;
            this.cost = hourlyRate + (hourlyRate * minutes);

            return this.GetCost();
        }

        public decimal AddCoin(decimal amount)
        {
            this.balance += amount;
            if(this.balance >= this.cost)
            {
                this.GetCurrentTicket().SetPaid(true);
                return this.balance - this.cost;
            } else
            {
                return -1;
            }
        }

        public string GetCostLabel()
        {
            return "Please Insert: " + this.FormatCurrency(this.cost - this.balance);
        }

        public string FormatCurrency(decimal value)
        {
            return value.ToString("C2");
        }

        public string CheckIfFullyPaid(decimal amount)
        {
            decimal change = this.AddCoin(amount);

            if (change >= 0)
            {
                this.balance = 0;
                this.cost = 0;
                this.currentTicket = null;

                return "Thank you for paying. Take your ticket"
                    + (change == 0 ? "" : " and your " + this.FormatCurrency(change) + " change") + " from the machine.";
            }
            else
            {
                return null;
            }
        }

    }
}
