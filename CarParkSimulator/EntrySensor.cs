using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    class EntrySensor : Sensor
    {
        CarPark carPark;

        public EntrySensor(CarPark carPark)
        {
            this.carPark = carPark;
        }
        public override void CarDetected()
        {
            base.CarDetected();

            carPark.CarArrivedAtEntrance();
        }

        public override void CarLeftSensor()
        {
            base.CarLeftSensor();

            carPark.CarEnteredCarPark();
        }
    }
}