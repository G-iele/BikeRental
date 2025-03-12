using BikeRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BikeRental.Models
{
    public class MTB: Bike
    {
        protected string SuspensionType { get; set; }
        protected bool DropperPost { get; set; }
        
        public MTB ()
        {

        }
        public MTB (int id, string brand, string breakType, decimal rentalRate,string suspensionType, bool dropperPost)
        {
            Id = id;
            Brand = brand;
            BreakType = breakType;
            RentalRate = rentalRate;
            SuspensionType = suspensionType;
            DropperPost = dropperPost;
            IsRented = false;
        }

        public override string ToCsvString()
        {
            return $"{Id},{Brand},{BreakType},{RentalRate},{SuspensionType},{DropperPost},{IsRented}";
        }

        public override void FromCsvString(string csvLine)
        {
            string[] bikeValues = csvLine.Split(',');

            Id = int.Parse(bikeValues[0]);
            Brand = bikeValues[1];
            BreakType = bikeValues[2];
            RentalRate = decimal.Parse(bikeValues[3]);
            SuspensionType = bikeValues[4];
            DropperPost = bool.Parse(bikeValues[5]);
            IsRented = bool.Parse(bikeValues[6]);
        }

        public override string ToString()
        {
            return $"Bike: {Id}, {Brand}, {BreakType}, {RentalRate}, {SuspensionType}, {DropperPost}, {IsRented}";
        }
    }
}

