using System;

namespace Parking
{
    public class Car : IVehicle<Car>
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public bool IsDiesel { get; set; }
        public bool IsElectric { get; set; }

        public bool IsParked { get; set; }
        public Parking<Car> Parking { get; set; }

        public TypeOfVehiclecs Type { get; set; } = TypeOfVehiclecs.Car;

        public string GetTypeOfVehicle()
        {
            return $"{Make}-{Model}";
        }

        public void LeaveParking()
        {
            Parking.LeaveVehicle(this);
        }

        public void EnterParking(Parking<Car> parking)
        {
            if (parking.FreeCapacity <= 0)
            {
                return;
            }
            parking.ParkVehicle(this);
            IsParked = true;
        }
    }
}