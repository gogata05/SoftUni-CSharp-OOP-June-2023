using System.Collections.Generic;

namespace RobotService.Repositories.Contracts
{
    public interface IRepository<T>
    {
        IReadOnlyCollection<T> Models();

        void AddNew(T model);

        bool RemoveByName(string typeName);

        T FindByStandard(int interfaceStandard);
    }
}
