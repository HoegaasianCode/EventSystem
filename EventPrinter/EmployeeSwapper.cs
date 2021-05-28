using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPrinter
{
    class EmployeeSwapper
    {
        private readonly Employees _employees;
        private readonly Teams _teams;
        private readonly Departments _departments;

        public EmployeeSwapper(Employees employees, Teams teams, Departments departments) 
        {
            _employees = employees;
            _teams = teams;
            _departments = departments;
        }

        public void SwapController()
        {
            for (int i = 0; i < _employees.EmployeeArray.Length; i++)
            {
                Employee employee = _employees.EmployeeArray[i];
                for(int j = 0; j < employee.TransferEventRecord.Count; j++)
                {
                    string[] @event = employee.TransferEventRecord[j];
                    if (@event[0].ToLower() == "byttet team") SetNewTeam(employee, @event);
                    if (@event[0].ToLower() == "byttet avdeling/team")
                    {
                        //SetNewDepartment(employee, @event); <- copy the code below
                        //SetNewTeam(employee, @event);
                    }
                }
            }
        }

        private void SetNewTeam(Employee employee, string[] @event)
        {
            for (int i = 0; i < _teams.TeamList.Count; i++)
            {
                Team team = _teams.TeamList[i];
                if (@event[1].Contains(team.Name))
                {
                    employee.Team.RemoveMember(employee);
                    employee.Team = team;
                    team.AddMember(employee);
                }
            }
        }

        // Test case: "Byttet team,til Team2, 2"
        // -> "Ansatt2" i Employees.cs skal nå stå som under "Team2"
        // -> "Team2" i Teams.cs skal ha 5 medlemmer:
        // 3 fra InitialDataGenerator.cs 
        // 1 fra TextFile1.txt (nyansatt)
        // 1 fra dette byttet
        // Det forrige teamet til Ansatt2 (Team1), skal nå ha to medlemmer:
        // 2 fra InitialDataGenerator.cs

        public void TestSwappedTeamName()
        {
            foreach(var employee in _employees.EmployeeArray)
            {
                if (employee.FirstName == "Ansatt2") Console.Write(employee.Team.Name);
            }
        }

        public void TestAllMembersInSwappedTeam()
        {
            foreach (var team in _teams.TeamList)
            {
                if (team.Name == "Team2")
                {
                    foreach(var member in team.Members)
                    {
                        Console.WriteLine(member.FirstName);
                    }
                }
            }
        }

        public void TestPriorTeamMembers()
        {
            foreach (var team in _teams.TeamList)
            {
                if (team.Name == "Team1")
                {
                    foreach (var member in team.Members)
                    {
                        Console.WriteLine(member.FirstName);
                    }
                }
            }
        }
    }
}
