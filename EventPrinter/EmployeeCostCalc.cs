using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPrinter
{
    class EmployeeCostCalc
    {
        private readonly string[][] _costEvents;
        private readonly Employees _employees;

        public EmployeeCostCalc(Employees employees, string[][] costEvents)
        {
            _costEvents = costEvents;
            _employees = employees;
        }

        public void CostController()
        {
            for (int i = 0; i < _employees.EmployeeArray.Length; i++)
            {
                Employee employee = _employees.EmployeeArray[i];
                for(int j = 0; j < employee.CostEventRecord.Count; j++)
                {
                    string[] @event = employee.CostEventRecord[j];
                    if (@event[0].ToLower() == "individuell lønnsøkning") RaiseSalary(@event, employee);
                    if (@event[0].ToLower() == "stillingsøkning") IncreasePosition(@event, employee);
                    if (@event[0].ToLower() == "stillingsreduksjon") DecreasePosition(@event, employee);
                    if (@event[0].ToLower() == "sluttet/permitert") SetZeroSalary(employee);
                }
            }
        }

        public void IsGlobalRaise()
        {
            for (int i = 0; i < _costEvents.Length; i++)
            {
                string[] costEvent = _costEvents[i];
                if (costEvent[0].ToLower() == "global lønnsøkning")
                {
                    RaiseAllSalaries(costEvent[1]);
                    break;
                }     
            }
        }

        private void RaiseAllSalaries(string percentage)
        {
            string noPercentageChar = RemoveLastChar(percentage);
            double rate = 1 + ToDouble(noPercentageChar) / 100;
            for(int i = 0; i < _employees.EmployeeArray.Length; i++)
            {
                Employee employee = _employees.EmployeeArray[i];
                employee.Cost *= rate;
            }

        }

        private static void RaiseSalary(string[] @event, Employee employee)
        {
            employee.Salary += ToDouble(@event[1]);
            employee.Cost += ToDouble(@event[1]);
        }

        private static void IncreasePosition(string[] @event, Employee employee)
        {
            string noPercentageChar = RemoveLastChar(@event[1]);
            double rateOfIncrease = ToDouble(noPercentageChar);
            double previousPercentage = employee.PositionPercentage;
            double currentPercentage = previousPercentage + rateOfIncrease;
            double projectedCost = employee.Cost / (previousPercentage / 100);
            employee.Cost = projectedCost * (currentPercentage / 100);
            employee.PositionPercentage = currentPercentage;
        }

        private static void DecreasePosition(string[] @event, Employee employee)
        {
            string noPercentageChar = RemoveLastChar(@event[1]);
            double rateOfDecrease = ToDouble(noPercentageChar);
            double previousPercentage = employee.PositionPercentage;
            double currentPercentage = previousPercentage - rateOfDecrease;
            double projectedCost = employee.Cost / (previousPercentage / 100);
            employee.Cost = projectedCost * (currentPercentage / 100);
            employee.PositionPercentage = currentPercentage;
        }

        private static void SetZeroSalary(Employee employee)
        {
            employee.Salary = 0;
            employee.Cost = 0;
        }

        private static double ToDouble(string s) => Double.Parse(s);
        private static string RemoveLastChar(string s) => s.Remove(s.Length - 1);

        public void TestIndividualRaise()
        {
            // Test case: "Individuell lønnsøkning,50000,1"
            // "Ansatt1" skal nå ha 650000 i lønnskostnad
            foreach (var employee in _employees.EmployeeArray)
            {
                if (employee.FirstName == "Ansatt1") Console.Write(employee.Cost);
            }
        }

        public void TestPositionIncrease()
        {
            // Test case: "Stillingsøkning,20%,2"
            // "Ansatt2" skal nå gått fra 60% til 80% stilling
            // "Ansatt2" skal nå ha 480000 (prosjisert lønn * 0.8) i lønnskostnad
            foreach (var employee in _employees.EmployeeArray)
            {
                if (employee.FirstName == "Ansatt2")
                {
                    Console.WriteLine(employee.Cost);
                    Console.WriteLine(employee.PositionPercentage);
                }
            }
        }

        public void TestPositionDecrease()
        {
            // Test case: "Stillingsreduksjon,50%,3"
            // "Ansatt3" skal nå gått fra 75% til 25% stilling
            // "Ansatt3" skal nå ha 150000 (prosjisert lønn * 0.25 i lønnskostnad
            foreach (var employee in _employees.EmployeeArray)
            {
                if (employee.FirstName == "Ansatt3")
                {
                    Console.WriteLine(employee.Cost);
                    Console.WriteLine(employee.PositionPercentage);
                }
            }
        }

        public void TestGlobalRaise()
        {
            // Test case: "Global lønnsøkning,2.5%"
            // Alle ansatte skal nå ha 2.5% høyere lønnskostnad, etter individuelle økninger
            // For eksempel skal "Ansatt2" ha 492000 i lønnskostnad
            foreach (var employee in _employees.EmployeeArray)
            {
                if(employee.FirstName == "Ansatt2")
                Console.WriteLine(employee.Cost);
            }
        }
    }
}
