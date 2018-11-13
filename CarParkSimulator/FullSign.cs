using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    public class FullSign
    {
        private bool lit;

        public bool IsLit()
        {
            return lit;
        }

        public void SetLit(bool isLit)
        {
            lit = isLit;
        }
    }
}
