using BikeRental.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRental.Models
{
    public class Client: ICSVSerializable
    {
        private int Id { get; set; }
        private string Name { get; set; }
        private List<int> BikeIds { get; set; } 

        public Client(int clientId, string name, List<int> bikeIds)
        {
            Id = clientId;
            Name = name;
            BikeIds = bikeIds;
        }

        public virtual string ToCsvString()
        {
            return $"{Id},{Name},{BikeIds}";
        }
    }
}
