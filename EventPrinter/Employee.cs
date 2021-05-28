using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPrinter
{
    class Employee
    {
        public readonly string FirstName;
        public readonly string LastName;
        public string Position;
        public double PositionPercentage;
        public double Salary;
        public Department Department;
        public Team Team;
        public readonly string SocialSecurityNo;
        public List<string[]> CostEventRecord { get; set; }
        public List<string[]> TransferEventRecord { get; set; }
        public double Cost { get; set; }


        public Employee(string firstName, string lastName, string position,
            int positionPercentage, int salary, Department department, Team team,
            string socialSecurityNo)
        {
            FirstName = firstName;
            LastName = lastName;
            Position = position;
            PositionPercentage = positionPercentage;
            Salary = salary;
            Department = department;
            Team = team;
            SocialSecurityNo = socialSecurityNo;
            Cost = Salary;
            CostEventRecord = new();
            TransferEventRecord = new();
        }
    }
}
