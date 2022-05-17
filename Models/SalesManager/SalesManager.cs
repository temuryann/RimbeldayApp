using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SalesManager
{
    public class SalesManager
    {
        public string FullName { get; set; }
        public double Salary { get; set; }
        public double Bonus { get; set; }
        public double OvertimeBonus { get; set; }
        public int Overtime { get; set; }
        public decimal AllBalance { get; set; }

        public SalesManager()
        {

        }

        public SalesManager(string fullName, double salary, int overTime)
        {
            FullName = fullName;
            Salary = salary;
            Bonus += salary;
            Overtime = overTime;
            OvertimeBonus = GetOvertimeBonus();
            AllBalance = (decimal)(Salary + Bonus + OvertimeBonus);
        }

        private double GetOvertimeBonus()
        {
            double overTimeBonus;

            if (OvertimeBonus == 1)
                overTimeBonus = Salary * 0.5 / 100;
            else if (OvertimeBonus > 1 && OvertimeBonus < 3)
                overTimeBonus = Salary * 10 / 100;
            else
                overTimeBonus = Salary * 20 / 100;

            return overTimeBonus;
        }
    }
}
