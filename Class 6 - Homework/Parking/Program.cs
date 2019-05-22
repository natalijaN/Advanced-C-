using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            // Generate Car`s Parking and Cars

            Parking<Car> carParking = new Parking<Car>(2);

            Car astra = new Car
            {
                Make = "Opel",
                Model = "Astra"
            };

            Car fiat = new Car
            {
                Make = "Fiat",
                Model = "Punto"
            };

            Car suzuki = new Car
            {
                Make = "Suzuki",
                Model = "Swift"
            };

            Console.WriteLine();
            Console.WriteLine("Parking cars:");
            Console.WriteLine();

            carParking.ParkVehicle(astra);
            carParking.ParkVehicle(fiat);
            carParking.ParkVehicle(suzuki);

            Console.WriteLine();
            Console.WriteLine("Cars leaving parking: ");
            Console.WriteLine();

            carParking.LeaveVehicle(suzuki);
            astra.LeaveParking();
            astra.EnterParking(carParking);

            Console.WriteLine();
            Console.WriteLine("Parking cars:");
            Console.WriteLine();

            carParking.ParkVehicle(suzuki);

            //Generate Boat and Boat`s Parking

            Parking<Boat> boatParking = new Parking<Boat>(1);

            Boat Milena = new Boat();
            Milena.Name = "Milena";

            Boat BlackPearl = new Boat();
            BlackPearl.Name = "BlackPearl";

            Console.WriteLine();
            Console.WriteLine("Parking boats");
            Console.WriteLine();

            boatParking.ParkVehicle(Milena);
            boatParking.ParkVehicle(BlackPearl);

        }
    }
}
