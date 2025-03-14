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
        protected string Type { get; set; }
        protected string SuspensionType { get; set; }
        protected bool DropperPost { get; set; }
        
        public MTB ()
        {

        }
        public MTB (int id,string type, string brand, string breakType, decimal rentalRate,string suspensionType, bool dropperPost)
        {
            Id = id;
            Type = type;
            Brand = brand;
            BreakType = breakType;
            RentalRate = rentalRate;
            SuspensionType = suspensionType;
            DropperPost = dropperPost;
            IsRented = false;
        }

        public override string ToCsvString()
        {
            return $"{Id},{Type},{Brand},{BreakType},{RentalRate},{SuspensionType},{DropperPost},{IsRented}";
        }

        public override void FromCsvString(string csvLine)
        {
            string[] bikeValues = csvLine.Split(',');

            Id = int.Parse(bikeValues[0]);
            Type = bikeValues[1];
            Brand = bikeValues[2];
            BreakType = bikeValues[3];
            RentalRate = decimal.Parse(bikeValues[4]);
            SuspensionType = bikeValues[5];
            DropperPost = bool.Parse(bikeValues[6]);
            IsRented = bool.Parse(bikeValues[7]);
        }

        public override string ToString()
        {
            return $"Bike: {Id}, {Type}, {Brand}, {BreakType}, {RentalRate}, {SuspensionType}, {(DropperPost ? "Has" : "Does not have")} dropper post, Is rented: {IsRented}.";
        }
    }
}

