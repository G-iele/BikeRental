using BikeRental.Contracts;
using BikeRental.Models;
using BikeRental.Repositories;
using BikeRental.Services;
using System.Xml.Linq;

namespace BikeRental
{
    public class Program
    {
        public static void Main()
        {
            DataRepo<Client> clientRepo = new DataRepo<Client>("client.csv");
            IClientService clientService = new ClientService(clientRepo);

            DataRepo<MTB> mtbRepo = new DataRepo<MTB>("mtb.csv");
            IBikeService<MTB> mtbBikeService = new BikeService<MTB>(mtbRepo);

            DataRepo<EBike> eBikeRepo = new DataRepo<EBike>("eBike.csv");
            IBikeService<EBike> eBikeService = new BikeService<EBike>(eBikeRepo);


            int action = 0;
            bool isValidInput = true;

            do
            {
                Console.WriteLine("\n1. Add bike");
                Console.WriteLine("2. Show all bikes");
                Console.WriteLine("3. Find bike by type");
                Console.WriteLine("4. Add client");
                Console.WriteLine("5. Show all clients");
                Console.WriteLine("6. Rent bike");
                Console.WriteLine("7. Bike return");
                Console.WriteLine("0. Close program\n");

                isValidInput = int.TryParse(Console.ReadLine(), out action);

                if (isValidInput)
                {
                    switch(action)
                    {
                        case 1:
                            Console.WriteLine("What type of bike you want to add (1: MTB, 2: EBike): ");
                            int.TryParse(Console.ReadLine(), out int bikeType);

                            string selectedType = string.Empty;

                            switch (bikeType)
                            {
                                case 1:
                                    selectedType = "MTB";
                                    break;
                                case 2:
                                    selectedType = "EBike";
                                    break;
                                default:
                                    Console.WriteLine("Selected type does not exist.");
                                    continue;
                            }

                            Random randBikeId = new Random();
                            int bikeId = randBikeId.Next(0, 1001);

                            Console.WriteLine("Bike brand: ");
                            string brand = Console.ReadLine();

                            Console.WriteLine("Bike break type: ");
                            string breakType = Console.ReadLine();

                            Console.WriteLine("Bike rental rate: ");
                            decimal.TryParse(Console.ReadLine(), out decimal rentalRate);

                            switch (bikeType)
                            {
                                case 1:
                                    Console.WriteLine("Bike suspension type: ");
                                    string suspensionType = Console.ReadLine();

                                    Console.WriteLine("Bike dropper post (1: true, 2: false): ");
                                    int.TryParse(Console.ReadLine(), out int type);

                                    bool dropperPost;

                                    if (type == 1)
                                    {
                                        dropperPost = true;
                                    }
                                    else
                                    {
                                        dropperPost = false;
                                    }

                                    MTB bike = new MTB(bikeId, selectedType, brand, breakType, rentalRate, suspensionType, dropperPost);
                                    mtbBikeService.AddBike(bike);
                                    break;
                                case 2:
                                    Console.WriteLine("Bike motor power: ");
                                    int motorPower = int.Parse(Console.ReadLine());

                                    Console.WriteLine("Bike battery capacity: ");
                                    int batteryCapacity = int.Parse(Console.ReadLine());

                                    EBike ebike = new EBike(bikeId, selectedType, brand, breakType, rentalRate, motorPower, batteryCapacity);
                                    eBikeService.AddBike(ebike);
                                    break;
                                default:
                                    Console.WriteLine("Selected type does not exist.");
                                    continue;
                            }
                                break;
                        case 2:
                            foreach (MTB c in mtbBikeService.GetBikes())
                            {
                                Console.WriteLine(c.ToString());
                            }

                            foreach (EBike c in eBikeService.GetBikes())
                            {
                                Console.WriteLine(c.ToString());
                            }
                            break;
                        case 3:
                            Console.WriteLine("What type of bike you want to find (1: MTB, 2: EBike): ");
                            int.TryParse(Console.ReadLine(), out int selectedBikeType);

                            switch (selectedBikeType)
                            {
                                case 1:
                                    foreach (MTB c in mtbBikeService.GetBikes())
                                    {
                                        Console.WriteLine(c.ToString());
                                    }
                                    break;
                                case 2:
                                    foreach (EBike c in eBikeService.GetBikes())
                                    {
                                        Console.WriteLine(c.ToString());
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Selected bike type does not exist.");
                                    continue;
                            }
                            break;
                        case 4:
                            Random randClientId = new Random();  
                            int clientId = randClientId.Next(0, 1001);

                            Console.WriteLine("Client name: ");
                            string name = Console.ReadLine();

                            Client client = new Client(clientId, name);
                            clientService.AddClient(client);
                            break;
                        case 5:
                            foreach(Client c in clientService.GetClients())
                            {
                                Console.WriteLine(c.ToString());
                            }
                            break;
                        case 6:
                            Console.WriteLine("Enter bike ID that you want to rent: ");
                            int.TryParse(Console.ReadLine(), out int bikeToRentId);

                            Console.WriteLine("Enter client ID: ");
                            int.TryParse(Console.ReadLine(), out int clientToRentId);

                                if (mtbBikeService.ReserveBike(bikeToRentId))
                                {
                                    Bike bike = mtbBikeService.ReservedTempBike;
                                    Client clientToRent = clientService.GetClient(clientToRentId);

                                    if(clientService.RentBikeToClient(clientToRentId, bikeToRentId))
                                    {
                                    mtbBikeService.RentBike();
                                    Console.WriteLine($"Bike id: {bike.Id}, brand: {bike.Brand} is rented to client name: {clientToRent.Name}, client id: {clientToRent.Id}.");
                                    }

                                }
                                else if (eBikeService.ReserveBike(bikeToRentId)) 
                                {
                                    Bike bike = eBikeService.ReservedTempBike;
                                    Client clientToRent = clientService.GetClient(clientToRentId);

                                    if (clientService.RentBikeToClient(clientToRentId, bikeToRentId))
                                    {
                                        eBikeService.RentBike();
                                    Console.WriteLine($"Bike id: {bike.Id}, brand: {bike.Brand} is rented to client name: {clientToRent.Name}, client id: {clientToRent.Id}.");
                                    }
                                } 
                                else
                                {
                                    Console.WriteLine("Bike could't be rented.");
                                }
                            break;
                        case 7:
                            Console.WriteLine("Enter bike ID that you want to return: ");
                            int.TryParse(Console.ReadLine(), out int bikeToReturnId);

                            Console.WriteLine("Enter client ID: ");
                            int.TryParse(Console.ReadLine(), out int clientToReturntId);

                            if (mtbBikeService.ReturnBike(bikeToReturnId))
                            {
                                Bike bike = mtbBikeService.GetBike(bikeToReturnId);
                                Client clientToRent = clientService.GetClient(clientToReturntId);
                                clientService.RenturnBikeFromClient(clientToReturntId, bikeToReturnId);
                                Console.WriteLine($"Bike id: {bike.Id}, brand: {bike.Brand} is returned from client name: {clientToRent.Name}, client id: {clientToRent.Id}.");
                            }
                            else if (eBikeService.ReturnBike(bikeToReturnId))
                            {
                                Bike bike = eBikeService.GetBike(bikeToReturnId);
                                Client clientToRent = clientService.GetClient(clientToReturntId);
                                clientService.RenturnBikeFromClient(clientToReturntId, bikeToReturnId);
                                Console.WriteLine($"Bike id: {bike.Id}, brand: {bike.Brand} is returned from client name: {clientToRent.Name}, client id: {clientToRent.Id}.");
                            }
                            else
                            {
                                Console.WriteLine("Bike could't be returned.");
                            }
                                break;
                        case 0:
                            break;
                        default:
                            Console.WriteLine("Incorrect choice. Please select a valid program number.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input. Please select a valid program number.");
                }
            }
            while (  action != 0 || !isValidInput);

        }
    }
}