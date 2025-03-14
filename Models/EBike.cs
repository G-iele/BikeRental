using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRental.Models
{
   public class EBike: Bike
    {
        protected string Type { get; set; }
        protected int MotorPower { get; set; }

        protected int BatteryCapacity { get; set; }

        public EBike()
        {

        }

        public EBike (int id, string type, string brand, string breakType, decimal rentalRate, int motorPower, int batteryCapacity)
        {
            Id = id;
            Type = type;
            Brand = brand;
            BreakType = breakType;
            RentalRate = rentalRate;
            MotorPower = motorPower;
            BatteryCapacity = batteryCapacity;
            IsRented = false;
        }

        public override string ToCsvString()
        {
            return $"{Id},{Type},{Brand},{BreakType},{RentalRate},{MotorPower},{BatteryCapacity},{IsRented}";
        }

        public override void FromCsvString(string csvLine)
        {
            string[] bikeValues = csvLine.Split(',');

            Id = int.Parse(bikeValues[0]);
            Type = bikeValues[1];
            Brand = bikeValues[2];
            BreakType = bikeValues[3];
            RentalRate = decimal.Parse(bikeValues[4]);
            MotorPower = int.Parse(bikeValues[5]);
            BatteryCapacity = int.Parse(bikeValues[6]);
            IsRented = bool.Parse(bikeValues[7]);
        }

        public override string ToString()
        {
            return $"Bike: {Id}, {Type}, {Brand}, {BreakType}, {RentalRate}, {MotorPower}, {BatteryCapacity}, Is rented: {IsRented}";
        }
    }
}
