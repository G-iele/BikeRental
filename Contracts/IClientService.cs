using BikeRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRental.Contracts
{
    public interface IClientService
    {
        void AddClient(Client client);
        Client? GetClient(int clientId);
        List<Client> GetClients();
        bool RentBikeToClient(int clientToRentId, int bikeToRentId);
        void RenturnBikeFromClient(int clientToReturntId, int bikeToReturntId);
    }
}
