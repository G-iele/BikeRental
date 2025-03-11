namespace BikeRental
{
    public class Program
    {
        public static void Main()
        {
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
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
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