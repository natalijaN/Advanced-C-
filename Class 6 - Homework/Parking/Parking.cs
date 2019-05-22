using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    public class Parking<T>  where T : IVehicle<T>
    
    {
        public int Capacity { get; private set; }
        public int Occupancy { get; private set; }
        public int FreeCapacity { get; private set; }

        private List<T> parkedVehicles = new List<T>();


        public Parking(int capacity)
        {          
            Capacity = capacity;
            FreeCapacity = capacity;
            Occupancy = 0;
        }

        public void ParkVehicle(T vehicle)
        {         
            if (FreeCapacity > 0)
            {
                Occupancy += 1;
                FreeCapacity -= 1;
                vehicle.IsParked = true;             
                vehicle.Parking = this; 
                parkedVehicles.Add(vehicle);
                Console.WriteLine($"{vehicle.GetTypeOfVehicle()} is parked!");
                
            }
            else
            {
                Console.WriteLine($"There is no place on this parking for {vehicle.GetTypeOfVehicle()}!");
                Console.WriteLine();
            }
        }

        public void LeaveVehicle(T vehicle)
        {
            bool flag = false;
            foreach (var parkVehice in parkedVehicles)
            {
                if (parkVehice.GetTypeOfVehicle() == vehicle.GetTypeOfVehicle())
                {
                    Occupancy -= 1;
                    FreeCapacity += 1;
                    parkedVehicles.Remove(vehicle);
                    flag = true;
                }
                if (flag)
                {
                    break;
                }
            }

            if (flag == true)
            {
                vehicle.IsParked = false;
                vehicle.Parking = null;
                Console.WriteLine($"{vehicle.GetTypeOfVehicle()} left the parking!");
            }

            else
                Console.WriteLine($"The vehicle {vehicle.GetTypeOfVehicle()} has never been on this parking!");
        }

       
    }
}
