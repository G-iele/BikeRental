using BikeRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRental.Contracts
{
    public interface IBikeService<T> where T : Bike
    {
        T ReservedTempBike { get; }
        void AddBike(T bike);
        List<T> GetBikes();
        T GetBike(int bikeToRentId);
        bool ReserveBike(int bikeToRentId);
        void RentBike();
        bool ReturnBike(int bikeToReturntId);
    }
}
