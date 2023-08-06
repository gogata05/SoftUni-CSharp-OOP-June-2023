using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public class Student : Client
    {
        private const int interest = 2;
        public Student(string name, string id, double income) : base(name, id, interest, income)
        {
        }
        public override void IncreaseInterest()//?
        {
            int newInterest = this.Interest + 1;
            this.Interest = newInterest;
        }
        //This class will be only accepted in combination with BranchBank. For more clarity, see the AddClient command in the business logic section of this document.

    }
}
