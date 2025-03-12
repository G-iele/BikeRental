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
                            int bikeType = int.Parse(Console.ReadLine());

                            Random randBikeId = new Random();
                            int bikeId = randBikeId.Next(0, 1001);

                            Console.WriteLine("Bike brand: ");
                            string brand = Console.ReadLine();

                            Console.WriteLine("Bike break type: ");
                            string breakType = Console.ReadLine();

                            Console.WriteLine("Bike rental rate: ");
                            decimal rentalRate = decimal.Parse(Console.ReadLine());

                            if (bikeType == 1)
                            {
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

                                MTB bike = new MTB(bikeId, brand, breakType, rentalRate, suspensionType, dropperPost);
                                mtbBikeService.AddBike(bike);
                            } else if (bikeType == 2)
                            {
                                Console.WriteLine("Bike motor power: ");
                                int motorPower = int.Parse(Console.ReadLine());

                                Console.WriteLine("Bike battery capacity: ");
                                int batteryCapacity = int.Parse(Console.ReadLine());

                                EBike bike = new EBike(bikeId, brand, breakType, rentalRate, motorPower, batteryCapacity);
                                eBikeService.AddBike(bike);
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
                            break;
                        case 7:
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