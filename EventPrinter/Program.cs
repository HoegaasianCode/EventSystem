using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EventPrinter
{
    class Program // Readme.txt for assignment description
    {
        static void Main(string[] args)
        {
            InitialDataGenerator initialDataGenerator = new();
            initialDataGenerator.GenerateData();
            Departments departments = initialDataGenerator.Departments;
            Teams teams = initialDataGenerator.Teams;
            Employees employees = initialDataGenerator.Employees;
            LineReader lineReader = new();
            lineReader.ReadLines();
            string[][] employmentEvents = lineReader.EventOrganizer.EmploymentEvents;
            string[][] costEvents = lineReader.EventOrganizer.CostEvents;
            string[][] organizationalEvents = lineReader.EventOrganizer.OrganizationalEvents;
            DepartmentFactory departmentFactory = new(employmentEvents, departments);
            departmentFactory.CollectAllDepartmentStrings();
            //departmentFactory.Test();
            Departments departmentFactoryOutput = departmentFactory.Departments; // this is probably not necessary
            TeamFactory teamFactory = new(employmentEvents, teams);
            teamFactory.CollectAllTeamStrings();
            //teamFactory.Test();
            Teams teamFactoryOutput = teamFactory.Teams;
            EmployeeFactory employeeFactory = new(employmentEvents, organizationalEvents, departmentFactoryOutput,
                teamFactoryOutput, employees);
            employeeFactory.NewEmployee();
            Employees employeeFactoryOutput = employeeFactory.Employees;
            EmployeeDataUpdater employeeDataUpdater = new(employeeFactoryOutput, costEvents, organizationalEvents);
            employeeDataUpdater.UpdateNewEmployeeInfo();
            employeeDataUpdater.UpdateAllEmployeeEventRecords();
            //employeeDataUpdater.TestEventRecords();
            EmployeeSwapper employeeSwapper = new(employeeFactoryOutput, teamFactoryOutput,
                departmentFactoryOutput);
            employeeSwapper.SwapController();
            //employeeSwapper.TestSwappedTeamName();
            //employeeSwapper.TestAllMembersInSwappedTeam();
            //employeeSwapper.TestPriorTeamMembers();
            EmployeeCostCalc employeeCostCalc = new(employeeFactoryOutput, costEvents);
            employeeCostCalc.CostController();
            employeeCostCalc.IsGlobalRaise();
            //employeeCostCalc.TestIndividualRaise();
            //employeeCostCalc.TestPositionDecrease();
            //employeeCostCalc.TestPositionIncrease();
            //employeeCostCalc.TestGlobalRaise();
            OrganizationalCostCalc organizationalCostCalc = new(teamFactoryOutput, departmentFactoryOutput);
            organizationalCostCalc.SumTeamCost();
            organizationalCostCalc.SumDepartmentCost();
            CostReporter costReporter = new(employeeFactoryOutput, departmentFactoryOutput, teamFactoryOutput);
            costReporter.Run();
            StringBuilder stringBuilder = costReporter.Text;
            Console.Write(stringBuilder);
        }
    }
}
