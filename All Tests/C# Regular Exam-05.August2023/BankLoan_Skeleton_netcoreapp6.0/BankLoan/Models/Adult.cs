using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public class Adult : Client
    {
        private const int interest = 4;
        public Adult(string name, string id, double income) : base(name, id, interest, income)
        {
        }
        public override void IncreaseInterest()//?vir
        {
            int newInterest = this.Interest + 2;
            this.Interest = newInterest;
        }
        //This class will be only accepted in combination with CentralBank. For more clarity, see the AddClient command in the business logic section of this document.
    }
}
