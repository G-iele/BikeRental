using BikeRental.Contracts;
using BikeRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRental.Repositories
{
   public class DataRepo<T> where T: ICSVSerializable, new()
    {
        private readonly string _filePath;

        public DataRepo (string filePath)
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

        public List<T> GetData()
        {
            if(!File.Exists(_filePath))
            {
                return new List<T>();
            }

            List<T> data = new List<T>();

            StreamReader sr = new StreamReader(_filePath);

            while (!sr.EndOfStream)
            {
                T item = new T();
                item.FromCsvString(sr.ReadLine());
                data.Add(item);
            }
            sr.Close();

            return data;
        }

    }
}

