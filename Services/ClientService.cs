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
    public class ClientService: IClientService
    {
        private readonly DataRepo<Client> _dataRepo;

        private List<Client> Clients;

        public ClientService(DataRepo<Client> dataRepo)
        {
            _dataRepo = dataRepo;
            Clients = _dataRepo.GetData();
        }

       public void AddClient(Client client)
        {
            Clients.Add(client);
            _dataRepo.SaveData(Clients);
        }
       public List<Client> GetClients()
        {
            return Clients;
        }
        
    }
}
