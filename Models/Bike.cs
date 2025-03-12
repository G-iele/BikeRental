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

        protected bool IsRented { get; set; }


        public Bike()
        {

        }

        public virtual string ToCsvString()
        {
            return string.Empty;
        }

        public virtual void FromCsvString(string csvLine)
        {
        }

        public virtual string ToString()
        {
            return string.Empty;
        }
    }
}
