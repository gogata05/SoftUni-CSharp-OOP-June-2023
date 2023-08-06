using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {
        protected Bank(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.loans = new List<ILoan>();
            this.clients = new List<IClient>();
        }
        private string name;
        public string Name
        {
            get => name;
            private set => name = value;
        }
        //All names are unique.
        public int Capacity { get; private set; }

        private List<ILoan> loans;
        public IReadOnlyCollection<ILoan> Loans => this.loans.AsReadOnly();

        private List<IClient> clients;
        public IReadOnlyCollection<IClient> Clients => this.clients.AsReadOnly();

        public void AddClient(IClient Client)
        {
            if (clients.Count <= Capacity)
            {
                this.clients.Add(Client);
            }
            else
            {
                throw new ArgumentException($"Not enough capacity for this client.");
            }
        }
        public void AddLoan(ILoan loan)
        {
            this.loans.Add(loan);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Name: ");
            sb.Append(name);
            sb.Append(", Type: ");
            sb.AppendLine(this.GetType().Name);

            sb.Append("Clients: ");
            if (clients.Count > 0)
            {
                sb.AppendLine(string.Join(", ", clients.Select(c => c.Name)));
            }
            else
            {
                sb.AppendLine("none");
            }
            sb.Append("Loans: ");
            sb.Append(loans.Count);
            sb.Append(", Sum of Rates: ");
            sb.Append(SumRates().ToString());
            return sb.ToString().TrimEnd();
        }


        public void RemoveClient(IClient Client)
        {
            this.clients.Remove(Client);
        }
        public double SumRates()
        {
            return loans.Sum(x => x.InterestRate);
        }
    }
}
