using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Salaried : Employee
    {
        private double salary;
        public Salaried()
        {
            this.salary = 0;
        }
        public Salaried(string id, string name, string address, string phone, long sin, string dob, string dept, double salary)
           : base(id, name, address, phone, sin, dob, dept)

        {

            this.salary = salary;
        }

        public double EmployeeSalary
        {
            get { return salary; }
            set { salary = value; }
        }
        public override double GetPay()
        {
            return salary / 52;
        }

        public override string ToString()
        {
            return $"{this.name} has the lowest salary pay with ${GetPay().ToString("0.0")}";
        }

   
    }
}
