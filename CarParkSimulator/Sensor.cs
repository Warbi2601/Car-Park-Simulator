﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    public abstract class Sensor
    {
        protected bool carOnSensor;

        public virtual void CarDetected()
        {
            carOnSensor = true;
        }

        public virtual void CarLeftSensor()
        {
            carOnSensor = false;
        }

        public bool IsCarOnSensor()
        {
            return carOnSensor;
        }
    }
}