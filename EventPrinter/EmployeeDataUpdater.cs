using System;
using System.Collections.Generic;
using System.Linq;

namespace EventPrinter
{
    class EmployeeDataUpdater
    {
        private Employees _employees;
        private string[][] _costEvents;
        private string[][] _organizationalEvents;
        private Employee _employee;

        public EmployeeDataUpdater(Employees employees, string[][] costEvents,
            string[][] organizationalEvents)
        {
            _employees = employees;
            _costEvents = costEvents;
            _organizationalEvents = organizationalEvents;
        }

        public void UpdateNewEmployeeInfo()
        {
            for(int i = 0; i < _employees.NewEmployees.Count; i++)
            {
                _employee = _employees.NewEmployees[i];
                EmployeeToTeams();
                EmployeeToDepartments();
                if (_employee.Position.ToLower().Contains("boss")) SetManager();
                if (!_employee.Department.Teams.Contains(_employee.Team))
                {
                    TeamToDepartmentTeams();
                    SetTeamToDepartment();
                }
            }
        }

        public void UpdateAllEmployeeEventRecords()
        {
            ConsolidateEmployeeLists();
            EmployeeListToArray();
            AddToEmployeeCostEventRecord();
            AddToEmployeeTransferEventRecord();
        }

        private void EmployeeToTeams()
        {
            _employee.Team.Members.Add(_employee);
        }

        //Ansettelse,Ola1,Etternavn,Utvikler,100,600000,1F,Regnskap,1
        //Ansettelse,Ola2,Etternavn,Utvikler,100,600000,1D,Regnskap,2
        //Ansettelse,Ola3,Etternavn,Utvikler,100,600000,1F,Regnskap,3
        //Ansettelse,Mikael1,Etternavn,Bossman,100,1000000,1A,Ledelse,4
        //Ansettelse,Mikael2,Etternavn,Bossman,100,1000000,1A,Ledelse,5
        //Ansettelse,Mikael3,Etternavn,Bossman,100,1000000,1A,Team1,6

        private void EmployeeToDepartments()
        {
            _employee.Department.EmployeeCollection.Add(_employee);
        }

        private void TeamToDepartmentTeams()
        {
            _employee.Department.Teams.Add(_employee.Team);
        }

        private void SetTeamToDepartment()
        {
            _employee.Team.Department = _employee.Department;
        }

        private void SetManager()
        {
            _employee.Department.Manager = _employee;
        }

        private void ConsolidateEmployeeLists()
        {
            _employees.ConsolidateLists();
        }

        private void EmployeeListToArray()
        {
            _employees.ToArray();
        }

        private void AddToEmployeeCostEventRecord()
        {
            for(int i = 0; i < _employees.EmployeeArray.Length; i++)
            {
                Employee employee = _employees.EmployeeArray[i];
                for(int j = 0; j < _costEvents.Length; j++)
                {
                    string[] costEvent = _costEvents[j];
                    if (employee.SocialSecurityNo == costEvent.Last())
                    {
                        employee.CostEventRecord.Add(costEvent);
                    }
                }
            }
        }

        private void AddToEmployeeTransferEventRecord()
        {
            for (int i = 0; i < _employees.EmployeeArray.Length; i++)
            {
                Employee employee = _employees.EmployeeArray[i];
                for (int j = 0; j < _organizationalEvents.Length; j++)
                {
                    string[] organizationalEvent = _organizationalEvents[j];
                    if (employee.SocialSecurityNo == organizationalEvent.Last())
                    {
                        employee.TransferEventRecord.Add(organizationalEvent);
                    }
                }
            }
        }

        public void TestEventRecords()
        {
            // Test case: One employee has a different event-types happening to him/her
            // Output in this test should be "2" for 1 of each, etc.
            foreach(var employee in _employees.EmployeeArray)
            {
                if (employee.SocialSecurityNo == "2")
                {
                    Console.WriteLine(employee.CostEventRecord.Count);
                    Console.WriteLine(employee.TransferEventRecord.Count);
                }
            }
        }
    }
}
