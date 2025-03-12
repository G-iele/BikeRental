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
        List<Client> GetClients();

    }
}
