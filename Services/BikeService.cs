using BikeRental.Contracts;
using BikeRental.Models;
using BikeRental.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRental.Services
{
    class BikeService<T> : IBikeService<T> where T : Bike, new()
    {
        private readonly DataRepo<T> _dataRepo;

        private List<T> Bikes;

        public BikeService(DataRepo<T> dataRepo)
        {
            _dataRepo = dataRepo;
            Bikes = _dataRepo.GetData();

        }
        public void AddBike(T bike)
        {
            Bikes.Add(bike);
            _dataRepo.SaveData(Bikes);
        }

        public List<T> GetBikes()
        {
            return Bikes;
        }
    }
}
