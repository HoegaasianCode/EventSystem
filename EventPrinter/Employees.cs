using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPrinter
{
    class Employees
    {
        public List<Employee> EmployeeList { get; set; } = new();
        public Employee[] EmployeeArray { get; set; }
        public List<Employee> NewEmployees { get; set; } = new();
        public Employee[] NewEmployeeArray { get; set; }

        public void ConsolidateLists()
        {
            foreach(var employee in NewEmployees)
            {
                EmployeeList.Add(employee);
            }
        }

        public void ToArray()
        {
            EmployeeArray = EmployeeList.ToArray();
        }

    }
}
