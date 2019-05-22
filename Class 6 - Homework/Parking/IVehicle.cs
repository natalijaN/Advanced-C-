namespace Parking
{
    public interface IVehicle<T> where T: IVehicle<T>
    {
        bool IsParked { get; set; }
        Parking<T> Parking { get; set; }
        TypeOfVehiclecs Type { get; set; }

        void LeaveParking();
        void EnterParking(Parking<T> parking);

        string GetTypeOfVehicle();
    }
}