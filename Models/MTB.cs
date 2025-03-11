using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRental.Models
{
    public class MTB: Bike
    {
        private string SuspensionType { get; set; }
        private bool DropperPost { get; set; }

        public MTB (string suspensionType, bool dropperPost)
        {
            SuspensionType = suspensionType;
            DropperPost = dropperPost;
        }

        public override string ToCsvString()
        {
            return $"{Id},{Brand},{BreakType},{RentalRate},{SuspensionType},{DropperPost}";
        }
    }
}
