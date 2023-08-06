using BankLoan.Core.Contracts;
using BankLoan.Models.Contracts;
using BankLoan.Models;
using BankLoan.Repositories;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BankLoan.Core
{
    public class Controller : IController
    {
        private LoanRepository loans;
        private BankRepository banks;
        public Controller()
        {
            this.loans = new LoanRepository();
            this.banks = new BankRepository();
        }
        public string AddBank(string bankTypeName, string name)
        {
            Type bankType = Type.GetType($"BankLoan.Models.{bankTypeName}");

            if (bankType == null)
            {
                throw new ArgumentException(ExceptionMessages.BankTypeInvalid);
            }

            IBank bank = (IBank)Activator.CreateInstance(bankType, new object[] { name });
            this.banks.AddModel(bank);

            return string.Format(OutputMessages.BankSuccessfullyAdded, bankTypeName);
        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            Type clientType = Type.GetType($"BankLoan.Models.{clientTypeName}");
            if (clientType == null)
            {
                throw new ArgumentException(ExceptionMessages.ClientTypeInvalid);
            }
            IBank bank = this.banks.FirstModel(bankName);
            if ((bank is BranchBank && clientTypeName != "Student") || (bank is CentralBank && clientTypeName != "Adult"))
            {
                return OutputMessages.UnsuitableBank;
            }
            IClient client = (IClient)Activator.CreateInstance(clientType, new object[] { clientName, id, income });
            bank.AddClient(client);
            return string.Format(OutputMessages.ClientAddedSuccessfully, clientTypeName, bankName);
        }

        public string AddLoan(string loanTypeName)
        {
            Type loanType = Type.GetType($"BankLoan.Models.{loanTypeName}");

            if (loanType == null)
            {
                throw new ArgumentException(ExceptionMessages.LoanTypeInvalid);
            }

            ILoan loan = (ILoan)Activator.CreateInstance(loanType);
            this.loans.AddModel(loan);

            return string.Format(OutputMessages.LoanSuccessfullyAdded, loanTypeName);
        }

        public string FinalCalculation(string bankName)
        {
            IBank bank = this.banks.FirstModel(bankName);
            double funds = bank.Clients.Sum(c => c.Income) + bank.Loans.Sum(l => l.Amount);
            return string.Format(OutputMessages.BankFundsCalculated, bankName, funds.ToString("F2"));
        }



        public string ReturnLoan(string bankName, string loanTypeName)
        {
            ILoan loan = this.loans.FirstModel(loanTypeName);

            if (loan == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MissingLoanFromType, loanTypeName));
            }

            IBank bank = this.banks.FirstModel(bankName);
            bank.AddLoan(loan);
            this.loans.RemoveModel(loan);

            return string.Format(OutputMessages.LoanReturnedSuccessfully, loanTypeName, bankName);
        }

        public string Statistics()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var bank in this.banks.Models)
            {
                sb.AppendLine(bank.GetStatistics());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
