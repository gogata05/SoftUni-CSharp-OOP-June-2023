﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCommandPattern.Commands
{
    public class MinusCommand : Command
    {
        public MinusCommand(int operand) : base(operand)
        {
        }

        public override decimal Execute(decimal current)
        {
            return current - Operand;
        }

        public override decimal UnExecute(decimal current)
        {
            return current + Operand;
        }
    }
}