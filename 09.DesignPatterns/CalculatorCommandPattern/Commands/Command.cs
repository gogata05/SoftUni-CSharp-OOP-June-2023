using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalculatorCommandPattern
{
    public abstract class Command : ICommand
    {
        public Command(int operand)
        {
            Operand = operand;
        }

        public int Operand { get; set; }

        public abstract decimal Execute(decimal current);

        public abstract decimal UnExecute(decimal current);
    }
}