using BikeRental.Contracts;
using BikeRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRental.Repositories
{
   public class BikeRepo<T> where T: ICSVSerializable
    {
        private readonly string _filePath;

        public BikeRepo (string filePath)
        {
            _filePath = filePath;
        }

        public void SaveData(List<T> data)
        {
            using (StreamWriter sw = new StreamWriter(_filePath))
            {
                foreach(T item in data)
                {
                   sw.WriteLine(item.ToCsvString());
                }
            }
        }

    }
}

