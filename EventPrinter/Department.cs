using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPrinter
{
    class Department
    {
        public string Name;
        public List<Team> Teams { get; set; }
        public Employee Manager { get; set; }
        public List<Employee> EmployeeCollection { get; set; }
        public double Cost { get; set; }
        //public int ManagerSalaryBonus;

        public Department(string departmentName)
        {
            Name = departmentName;
            Teams = new();
            EmployeeCollection = new();
        }

        public void RemoveMember(Employee employee)
        {
            EmployeeCollection.Remove(employee);
        }

        public void AddMember(Employee member)
        {
            EmployeeCollection.Add(member);
        }

        public void SumDepartmentCost()
        {
            for (int i = 0; i < Teams.Count; i++)
            {
                Team team = Teams[i];
                Cost += team.Cost;
            }
        }
    }
}
