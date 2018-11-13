using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkSimulator
{
    public class SpaceSensor : Sensor
    {
        CarPark carPark;
        int spaceID;

        public SpaceSensor(CarPark carpark, int space)
        {
            this.carPark = carpark;
            this.spaceID = space;
        }
        
        public int getID()
        {
            return spaceID;
        }

        public override void CarDetected()
        {
            base.CarDetected();
        }

        public override void CarLeftSensor()
        {
            base.CarLeftSensor();
        }

    }
}
