using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Receptionist
{
    public class Receptionist
    {
        public string FullName { get; set; }
        public decimal Salary { get; set; }
        public decimal Bonus { get; set; }

        public Receptionist()
        {

        }

        public Receptionist(string fullName, decimal salary)
        {
            FullName = fullName;
            Salary = salary;
            Bonus = salary / 2;
        }
    }
}
