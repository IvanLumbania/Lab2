using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Lab2
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Employee> listOfEmployees = new List<Employee>();

            using (StreamReader readerFile = new StreamReader("C:\\Users\\ivanl\\source\\repos\\Lab2\\Lab2\\employees.txt"))
            {
                string readerLine;

                //Reads through the file txt and asssign 
                while ((readerLine = readerFile.ReadLine()) != null)
                {
                    string id = "";
                    string name = "";
                    string address = "";
                    string phone = "";
                    long sin = 0;
                    string dob = "";
                    string dept = "";
                    double rate = 0;
                    double hours = 0;
                    double salary = 0;
                    string[] data = readerLine.Split(":");

                    //Checks if they are in Salary Category and adds it to the listOfEmployees
                    if (data[0][0] <= '4' && data[0][0]>='0')
                    {
                        id = data[0];
                        name = data[1];
                        address = data[2];
                        phone = data[3];
                        sin = long.Parse(data[4]);
                        dob = data[5];
                        dept = data[6];
                        salary = double.Parse(data[7]);
                        listOfEmployees.Add(new Salaried(id, name, address, phone, sin, dob, dept, salary));

                    }

                    //Checks if they are in Wage Category and adds it to the listOfEmployees
                    else if (data[0][0] <= '7')
                    {
                        id = data[0];
                        name = data[1];
                        address = data[2];
                        phone = data[3];
                        sin = long.Parse(data[4]);
                        dob = data[5];
                        dept = data[6];
                        rate = double.Parse(data[7]);
                        hours = double.Parse(data[8]);
                        listOfEmployees.Add(new Wage(id, name, address, phone, sin, dob, dept, rate, hours));

                    }

                    //Checks if they are in Part Time Category and adds it to the listOfEmployees
                    else
                    {
                        id = data[0];
                        name = data[1];
                        address = data[2];
                        phone = data[3];
                        sin = long.Parse(data[4]);
                        dob = data[5];
                        dept = data[6];
                        rate = double.Parse(data[7]);
                        hours = double.Parse(data[8]);
                        listOfEmployees.Add(new PartTime(id, name, address, phone, sin, dob, dept, rate, hours));
                    }
                }

            }
            //Tracks Total weekly pay for all employees
            double totalWeeklyPay = 0;

            //Calls GetPay() for each employee
            for (int i = 0; i < listOfEmployees.Count; i++)
            {
                totalWeeklyPay += listOfEmployees[i].GetPay();
            }

            double allAvgWeeklyPay = totalWeeklyPay / Employee.employeeCounter;
            Console.WriteLine($"The average weekly pay for all employees: {allAvgWeeklyPay.ToString("0.0")}");

            //Tracker of who the highest and lowest pay is and its value
            double HighestWeeklyPay = 0.0;
            double LowestSalary = 0;
            string nameOfHighestWeeklyPay = "";
            string nameOfLowestSalary = "";

            //Loops through each employee and checks what type of employee they are (Wage or Salary)
            for (int i = 0; i < listOfEmployees.Count; i++)
            {
                if(listOfEmployees[i] is Wage )
                {
                    if (listOfEmployees[i].GetPay() > HighestWeeklyPay)
                    {
                        HighestWeeklyPay = listOfEmployees[i].GetPay();
                        nameOfHighestWeeklyPay = listOfEmployees[i].name;
                    }
                }
                  
                if ( LowestSalary == 0)
                {
                    LowestSalary = HighestWeeklyPay;
                }

                if (listOfEmployees[i] is Salaried )
                {
                    if (listOfEmployees[i].GetPay() < LowestSalary)
                    {
                        LowestSalary = listOfEmployees[i].GetPay();
                        nameOfLowestSalary = listOfEmployees[i].name;
                    }
                }
             
            }

            //Comapres The name of the highest and lowest weekly pay. Calls ToString Method if name matches
            for (int i = 0;i < listOfEmployees.Count; i++)
            {
                if (listOfEmployees[i].name == nameOfHighestWeeklyPay && listOfEmployees[i] is Wage)
                {
                    Console.WriteLine(listOfEmployees[i].ToString());
                }
                if (listOfEmployees[i].name == nameOfLowestSalary && listOfEmployees[i] is Salaried)
                {
                    Console.WriteLine(listOfEmployees[i].ToString());
                }

            }
            
            //Counts how many employees in each categories
            double salaryEmployee = 0;
            double wagesEmployee = 0;
            double partTimeEmployees = 0;

            //Loops through employee list and increments tracker 
            for (int i = 0;i < listOfEmployees.Count; i++)
            {
                if ((listOfEmployees[i] is Salaried))
                {
                    salaryEmployee++;
                }else if ((listOfEmployees[i] is Wage))
                {
                    wagesEmployee++;
                }
                else
                {
                    partTimeEmployees++;
                }

            }

            //Calculates the percentage 
            double percentOfSalaried = salaryEmployee / Employee.employeeCounter * 100;
            double percentOfWage = wagesEmployee / Employee.employeeCounter * 100;
            double percentOfPartTime = partTimeEmployees / Employee.employeeCounter * 100;

            //Prints
            Console.WriteLine($"Percentage of Salaried Employees: {percentOfSalaried.ToString("0.0")}%\n" +
                $"Percentage of Wage Employees: {percentOfWage.ToString("0.0")}%\n" +
                $"Percentage of Part Time Employees: {percentOfPartTime.ToString("0.0")}%");





        }

    }
}
