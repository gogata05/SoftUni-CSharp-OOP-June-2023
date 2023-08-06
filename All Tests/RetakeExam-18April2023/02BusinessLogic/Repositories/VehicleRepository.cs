namespace EDriveRent.Repositories
{
    using EDriveRent.Models.Contracts;
    using EDriveRent.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class VehicleRepository : IRepository<IVehicle>
    {
        private List<IVehicle> vehicles;
        public VehicleRepository()
        {
            this.vehicles = new List<IVehicle>();
        }
        public void AddModel(IVehicle vehicle)
        {
            this.vehicles.Add(vehicle);
        }

        public IVehicle FindById(string identifier) => this.vehicles.FirstOrDefault(u => u.LicensePlateNumber == identifier);

        public IReadOnlyCollection<IVehicle> GetAll() => this.vehicles;

        public bool RemoveById(string identifier) => this.vehicles.Remove(this.FindById(identifier));
    }
}
