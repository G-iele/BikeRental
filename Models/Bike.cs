using BikeRental.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BikeRental.Models
{
    public class Bike: ICSVSerializable
    {
        protected int Id { get; set; }
        protected string Brand { get; set; }
        protected string BreakType { get; set; }
        protected decimal RentalRate { get; set; }


        public Bike()
        {

        }

        public Bike (int id, string brand, string breakType, decimal rentalRate )
        {
            Id = id;
            Brand = brand;
            BreakType = breakType;
            RentalRate = rentalRate;
        }

        public virtual string ToCsvString()
        {
            return string.Empty;
        }
    }
}
