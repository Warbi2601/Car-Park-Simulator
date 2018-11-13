using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    public class Barrier
    {
        private bool lifted = false;

        public void Lower()
        {
            lifted = false;
        }

        public void Raise()
        {
            lifted = true;
        }

        public bool IsLifted()
        {
            return lifted;
        }
    }
}