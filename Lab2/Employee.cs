using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Employee
    {
        public string id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phone {get; set; }
        public long sin { get; set; }
        public string dob { get; set; }
        public string dept { get; set; }
        public static int employeeCounter;
        public Employee()
        {
            this.id = "";
            this.address = "";
            this.name = "";
            this.phone = "";
            this.sin = 0;
            this.dob = "";
            this.dept = "";
        }
        public Employee(string id, string name, string address, string phone,long sin, string dob, string dept)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.sin = sin;
            this.dob = dob;
            this.dept = dept;
            employeeCounter++;

        }
        public virtual double GetPay()
        {
            return 0.0;
        }
        public virtual string ToString()
        {
            return $"{this.name} is an Employee";
        }
    }
}
