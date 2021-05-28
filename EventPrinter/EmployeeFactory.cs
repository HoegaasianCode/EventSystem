using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPrinter
{
    class EmployeeFactory
    {
        private readonly string[][] _employmentEvents;
        private readonly string[][] _organizationalEvents;
        private readonly Departments _departments;
        private readonly Teams _teams;
        private Department _department;
        private Team _team;
        public Employees Employees { get; }

        public EmployeeFactory(string[][] employmentEvents, string[][] organizationalEvents,
            Departments departments
            , Teams teams, Employees employees)
        {
            _employmentEvents = employmentEvents;
            _organizationalEvents = organizationalEvents;
            _departments = departments;
            _teams = teams;
            Employees = employees;
        }

        public void NewEmployee()
        {
            for(int i = 0; i < _employmentEvents.Length; i++)
            {
                string[] eventArray = _employmentEvents[i];
                Employee employee = new(eventArray[1], eventArray[2], eventArray[3],
                    ToInt(eventArray[4]), ToInt(eventArray[5]), LookUpDepartment(eventArray[6]),
                    LookUpTeam(eventArray[7]), eventArray[8]);
                Employees.NewEmployees.Add(employee);
            }
        }

        private Department LookUpDepartment(string eventString)
        {
            for (int j = 0; j < _departments.DepartmentList.Count; j++)
            {
                Department department = _departments.DepartmentList[j];
                if (eventString == department.Name)
                {
                    _department = department;
                    break;
                }
            }
            return _department;
        }

        private Team LookUpTeam(string eventString)
        {
            for (int j = 0; j < _teams.TeamList.Count; j++)
            {
                Team team = _teams.TeamList[j];
                if (eventString == team.Name)
                {
                    _team = team;
                    break;
                }
            }
            return _team;
        }
        
        private static int ToInt(string s) => Int32.Parse(s);
        //private static double ToDouble(string s) => Double.Parse(s);

        public void Test1()
        {
            foreach(var emp in Employees.NewEmployees)
            {
                Console.WriteLine(emp.Team.Name);
            }
        }
    }
}
