using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    class ExitSensor : Sensor
    {
        CarPark carPark;

        public ExitSensor(CarPark carPark)
        {
            this.carPark = carPark;
        }

        public override void CarDetected()
        {
            base.CarDetected();

            carPark.CarArrivedAtExit();
        }

        public override void CarLeftSensor()
        {
            base.CarLeftSensor();

            carPark.CarExitedCarPark();
        }
    }
}
