using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Wage : Employee
    {
        private double rate ;
        private double hours;
        public Wage()
        {

        }
        public Wage(string id, string name, string address, string phone, long sin, string dob, string dept,double rate,  double hours)
            :base (id, name, address, phone, sin, dob, dept)
        {
            this.hours = hours;
            this.rate = rate;

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
            if (this.hours <= 40)
            {
                return this.rate * this.hours;

            }

            else
            {
                double overtimepay = (this.rate * 40) + ((this.rate * 1.5) * (this.hours - 40));
                return overtimepay;
            }
        }

        public override string ToString()
        {
            return $"{this.name} has the highest weekly pay for wages with ${GetPay().ToString("0.0")}";
                //$"The highest weekly pay for wages is:{this.name}";
        }
    }
}
