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

        public T ReservedTempBike { get; private set; }

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

        public T GetBike(int bikeToRentId)
        {
            return Bikes.Find(b => b.Id == bikeToRentId);
        }

        public bool ReserveBike(int bikeToRentId)
        {
            T bike = GetBike(bikeToRentId);

            if (bike is T && !bike.IsRented)
            {
                ReservedTempBike = bike;
                return true;
            }
            return false;
        }

        public void RentBike()
        {
            ReservedTempBike.IsRented = true;
            _dataRepo.SaveData(Bikes);
        }

        public bool ReturnBike(int bikeToReturntId)
        {
            T bike = GetBike(bikeToReturntId);

            if (bike is T && bike.IsRented)
            {
                bike.IsRented = false;
                return true;
            }
            return false;
        }
    }
}
