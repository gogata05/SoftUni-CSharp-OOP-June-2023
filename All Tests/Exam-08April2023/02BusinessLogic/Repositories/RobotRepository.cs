using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private List<IRobot> robots;
        public RobotRepository()
        {
            this.robots = new List<IRobot>();
        }
        public void AddNew(IRobot model)
        {
           this.robots.Add(model);
        }

        public IRobot FindByStandard(int interfaceStandard) => this.robots.FirstOrDefault(x => x.InterfaceStandards.Any(y => y == interfaceStandard));

        public IReadOnlyCollection<IRobot> Models() => this.robots.AsReadOnly();

        public bool RemoveByName(string robotModel) => this.robots.Remove(this.robots.FirstOrDefault(x => x.Model == robotModel));
    }
}
