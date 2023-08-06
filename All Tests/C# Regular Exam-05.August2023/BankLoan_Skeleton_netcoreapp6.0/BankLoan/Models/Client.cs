using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BankLoan.Models
{
    public abstract class Client : IClient
    {
        protected Client(string name, string id, int interest, double income)
        {
            this.Name = name;
            this.Id = id;
            this.Interest = interest;
            this.Income = income;
        }
        private string name;
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.ClientNameNullOrWhitespace));
                }
                name = value;
            }
        }
        private string id;
        public string Id
        {
            get => id;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.ClientIdNullOrWhitespace));
                }
                id = value;
            }
        }
        public int Interest { get; protected set; }
        private double income;
        public double Income
        {
            get => income;
            private set

            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.ClientIncomeBelowZero));
                }
                income = value;
            }
        }
        public abstract void IncreaseInterest();//Keep in mind that the child classes of Client will implement the method differently
    }
}
