using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test06
{
    internal class Person
    {
        public int age { get; set; }

        public Person(int age)
        {
            this.age = age;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
    }
}
