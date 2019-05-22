using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    public class Boat : IVehicle<Boat>
    {
        public string Name { get; set; }
        public bool BesPlatno { get; set; }

        public bool IsParked { get; set; }
        public Parking<Boat> Parking { get; set; }

        public TypeOfVehiclecs Type { get; set; } = TypeOfVehiclecs.Boat;   

        public string GetTypeOfVehicle()
        {
            return Name;
        }

        public void LeaveParking() 
        {
            Parking.LeaveVehicle(this);
        }

        public void EnterParking(Parking<Boat> parking)
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
