namespace EDriveRent.Repositories
{
    using EDriveRent.Models.Contracts;
    using EDriveRent.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    public class UserRepository : IRepository<IUser>
    {
        private List<IUser> users;
        public UserRepository()
        {
            this.users = new List<IUser>();
        }
        public void AddModel(IUser user)
        {
            this.users.Add(user);
        }

        public IUser FindById(string identifier) => this.users.FirstOrDefault(u => u.DrivingLicenseNumber == identifier);

        public IReadOnlyCollection<IUser> GetAll() => this.users;

        public bool RemoveById(string identifier) => this.users.Remove(this.FindById(identifier));
    }
}
