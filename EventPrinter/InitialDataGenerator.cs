using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPrinter
{
    class InitialDataGenerator
    {
        public Departments Departments { get; set; }
        public Teams Teams { get; set; }
        public Employees Employees { get; set; }

        public void GenerateData()
        {
            Department department = new("1A");
            Department department1 = new("1B");
            Departments departments = new();
            departments.DepartmentList.Add(department);
            departments.DepartmentList.Add(department1);
            Team team = new("Team1");
            Team team1 = new("Team2");
            Team team2 = new("Team3");
            Team team3 = new("Team4");
            team.Department = department; 
            team1.Department = department;
            team2.Department = department1;
            team3.Department = department1;
            department.Teams.Add(team);
            department.Teams.Add(team1);
            department1.Teams.Add(team2);
            department1.Teams.Add(team3);
            Teams teams = new();
            teams.TeamList.Add(team);
            teams.TeamList.Add(team1);
            teams.TeamList.Add(team2);
            teams.TeamList.Add(team3);
            Employee employee = new("Ansatt1", "EtterNavn", "Bossman", 100, 600000, department, team, "1");
            Employee employee1 = new("Ansatt2", "EtterNavn", "Utvikler", 60, 360000, department, team, "2");
            Employee employee2 = new("Ansatt3", "EtterNavn", "Utvikler", 75, 450000, department, team, "3");
            Employee employee3 = new("Ansatt4", "EtterNavn", "Utvikler", 100, 600000, department, team1, "4");
            Employee employee4 = new("Ansatt5", "EtterNavn", "Utvikler", 100, 600000, department, team1, "5");
            Employee employee5 = new("Ansatt6", "EtterNavn", "Utvikler", 100, 600000, department, team1, "6");
            Employee employee6 = new("Ansatt7", "EtterNavn", "Utvikler", 100, 600000, department1, team2, "7");
            Employee employee7 = new("Ansatt8", "EtterNavn", "Utvikler", 100, 600000, department1, team2, "8");
            Employee employee8 = new("Ansatt9", "EtterNavn", "Utvikler", 100, 600000, department1, team2, "9");
            Employee employee9 = new("Ansatt10", "EtterNavn", "Utvikler", 100, 600000, department1, team3, "10");
            Employee employee10 = new("Ansatt11", "EtterNavn", "Utvikler", 100, 600000, department1, team3, "11");
            Employee employee11 = new("Ansatt12", "EtterNavn", "Bossman", 100, 600000, department1, team3, "12");
            Employees employees = new();
            employees.EmployeeList.Add(employee);
            employees.EmployeeList.Add(employee1);
            employees.EmployeeList.Add(employee2);
            employees.EmployeeList.Add(employee3);
            employees.EmployeeList.Add(employee4);
            employees.EmployeeList.Add(employee5);
            employees.EmployeeList.Add(employee6);
            employees.EmployeeList.Add(employee7);
            employees.EmployeeList.Add(employee8);
            employees.EmployeeList.Add(employee9);
            employees.EmployeeList.Add(employee10);
            employees.EmployeeList.Add(employee11);
            team.AddMember(employee);
            team.AddMember(employee1);
            team.AddMember(employee2);
            team1.AddMember(employee3);
            team1.AddMember(employee4);
            team1.AddMember(employee5);
            team2.AddMember(employee6);
            team2.AddMember(employee7);
            team2.AddMember(employee8);
            team3.AddMember(employee9);
            team3.AddMember(employee10);
            team3.AddMember(employee11);
            department.EmployeeCollection.Add(employee);
            department.EmployeeCollection.Add(employee1);
            department.EmployeeCollection.Add(employee2);
            department.EmployeeCollection.Add(employee3);
            department.EmployeeCollection.Add(employee4);
            department.EmployeeCollection.Add(employee5);
            department.Manager = employee;
            department1.EmployeeCollection.Add(employee6);
            department1.EmployeeCollection.Add(employee7);
            department1.EmployeeCollection.Add(employee8);
            department1.EmployeeCollection.Add(employee9);
            department1.EmployeeCollection.Add(employee10);
            department1.EmployeeCollection.Add(employee11);
            department1.Manager = employee11;
            Departments = departments;
            Teams = teams;
            Employees = employees;
        }
    }
}
