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
        protected int Id { get; set; }
        protected string Name { get; set; }
        protected List<int> BikeIds { get; set; } 

        public Client()
        {
        }

        public Client(int clientId, string name, List<int> bikeIds = null)
        {
            Id = clientId;
            Name = name;
            BikeIds = bikeIds ?? new List<int>();
        }

        public string ToCsvString()
        {
            return $"{Id},{Name},{string.Join(";", BikeIds)}";
        }

        public void FromCsvString(string csvLine)
        {
            string[] clientValues = csvLine.Split(',');

            Id = int.Parse(clientValues[0]);
            Name = clientValues[1];

            if(clientValues[2].Length > 0)
            {
            BikeIds = clientValues[2].Split(';').Select(int.Parse).ToList();
            }
            else
            {
                BikeIds = new List<int>();
            }
        }
        public override string ToString()
        {
            string bikeIdsMsg = string.Empty;

            if (BikeIds.Count > 0)
            {
                bikeIdsMsg = $"Bikes Rented: {string.Join(", ", BikeIds)}";
            }
            else
            {
                bikeIdsMsg = $"No bikes currently rented.";
            }

            return $"Client: {Id}, {Name}, {bikeIdsMsg}";
        }

    }
}
