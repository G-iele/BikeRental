using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRental.Models
{
   public class EBike: Bike
    {
        protected int MotorPower { get; set; }

        protected int BatteryCapacity { get; set; }

        public EBike()
        {

        }

        public EBike (int id, string brand, string breakType, decimal rentalRate, int motorPower, int batteryCapacity)
        {
            Id = id;
            Brand = brand;
            BreakType = breakType;
            RentalRate = rentalRate;
            MotorPower = motorPower;
            BatteryCapacity = batteryCapacity;
            IsRented = false;
        }

        public override string ToCsvString()
        {
            return $"{Id},{Brand},{BreakType},{RentalRate},{MotorPower},{BatteryCapacity},{IsRented}";
        }

        public override void FromCsvString(string csvLine)
        {
            string[] bikeValues = csvLine.Split(',');

            Id = int.Parse(bikeValues[0]);
            Brand = bikeValues[1];
            BreakType = bikeValues[2];
            RentalRate = decimal.Parse(bikeValues[3]);
            MotorPower = int.Parse(bikeValues[4]);
            BatteryCapacity = int.Parse(bikeValues[5]);
            IsRented = bool.Parse(bikeValues[6]);
        }

        public override string ToString()
        {
            return $"Bike: {Id}, {Brand}, {BreakType}, {RentalRate}, {MotorPower}, {BatteryCapacity}, {IsRented}";
        }
    }
}
