using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRental.Models
{
   public class EBike: Bike
    {
        private int MotorPower { get; set; }

        private int BatteryCapacity { get; set; }

        public EBike (int motorPower, int batteryCapacity)
        {
            MotorPower = motorPower;
            BatteryCapacity = batteryCapacity;
        }

        public override string ToCsvString()
        {
            return $"{Id},{Brand},{BreakType},{RentalRate},{MotorPower},{BatteryCapacity}";
        }
    }
}
