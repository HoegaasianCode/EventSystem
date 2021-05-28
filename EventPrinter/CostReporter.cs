using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPrinter
{
    class CostReporter
    {
        private readonly Employees _employees;
        private readonly Departments _departments;
        private readonly Teams _teams;
        public StringBuilder Text { get; }

        public CostReporter(Employees employees, Departments departments, Teams teams)
        {
            _employees = employees;
            _departments = departments;
            _teams = teams;
            Text = new();
        }

        public void Run()
        {
            PrintEmployeeCount();
            PrintEmployeeCountPerDepartment();
            PrintTotalCost();
            PrintCostPerDepartmentAndTeam();
            PrintEmployeeCostPerDepartmentAndTeam();
        }

        private void PrintEmployeeCount()
        {
            Text.AppendLine($"Antall ansatte er nå: {_employees.EmployeeArray.Length}");
        }

        private void PrintEmployeeCountPerDepartment()
        {
            Text.AppendLine("Per avdeling: ");
            foreach(var department in _departments.DepartmentList)
            {
                Text.AppendLine(department.Name + ":" + " " + department.EmployeeCollection.Count);
            }
        }

        private void PrintTotalCost() // path of least resistance - sum from departments
        {
            double sum = 0; // 18mill... doesn't look quite right
            foreach(var department in _departments.DepartmentList)
            {
                sum += department.Cost;
            }
            
            Text.AppendLine($"Total kostnad for hele organisasjonen er nå: {sum}");
        }

        private void PrintCostPerDepartmentAndTeam()
        {
            Text.AppendLine("Per avdeling og team: ");
            foreach(var department in _departments.DepartmentList)
            {
                Text.AppendLine(department.Name + ":" + " " + department.Cost);
                foreach(var team in department.Teams)
                {
                    Text.AppendLine(team.Name + ":" + " " + team.Cost);
                }
            }
        }

        private void PrintEmployeeCostPerDepartmentAndTeam() // needs some work/testing
        {
            Text.AppendLine("Ansatte med årslønn, sortert etter avdeling, så team: ");
            foreach (var department in _departments.DepartmentList)
            {
                foreach(var team in department.Teams)
                {
                    foreach(var employee in team.Members)
                    {
                        Text.AppendLine(employee.FirstName + ":" + " " + employee.Cost);
                    }
                }
            }
        }
    }
}
