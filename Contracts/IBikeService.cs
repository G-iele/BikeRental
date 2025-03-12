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
        void AddBike(T bike);
        List<T> GetBikes();
    }
}
