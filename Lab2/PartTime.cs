using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class PartTime : Employee
    {
        private double rate;
        private double hours;

        public PartTime()
        {
            this.rate = 0;
            this.hours = 0;
        }
        public PartTime(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours) 
            : base(id, name, address, phone, sin, dob, dept)

        {
            this.rate = rate;
            this.hours = hours;
 
        }
        public double moneyRate
        {
            get { return rate; }
            set { rate = value; }
        }
        public double HoursRate
        {
            get { return hours; }
            set { hours = value; }
        }

        public override double GetPay()
        {
            return rate * hours;
        }
        public override string ToString()
        {
            return $" {this.name} is a part time";
        }

    }
}
