using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPrinter
{
    class DepartmentFactory
    {
        private readonly string[][] _lineArrayArray;
        public Departments Departments { get; }

        public DepartmentFactory(string[][] lineArrayArray, Departments departments)
        {
            _lineArrayArray = lineArrayArray;
            Departments = departments;
        }

        public void CollectAllDepartmentStrings()
        {
            List<string> stringList = new();
            for(int i = 0; i < _lineArrayArray.Length; i++)
            {
                string[] lineArray = _lineArrayArray[i];
                for(int j = 0; j < lineArray.Length; j++)
                {
                    stringList.Add(lineArray[6]);
                }
            }
            IsExistingDepartment(stringList);
        }

        private void IsExistingDepartment(List<string> stringList)
        {
            string[] distinctStringArray = stringList.Distinct().ToArray();
            for (int i = 0; i < distinctStringArray.Length; i++)
            {
                string distinctString = distinctStringArray[i];
                bool isUnique = true;
                for (int j = 0; j < Departments.DepartmentList.Count; j++)
                {
                    Department department  = Departments.DepartmentList[j];
                    if (distinctString == department.Name) isUnique = false;
                }
                if (isUnique) NewDepartment(distinctString);
            }
            Departments.ToArray();
        }

        private void NewDepartment(string distinctString)
        {
            Department department = new(distinctString);
            Departments.DepartmentList.Add(department);
        }

        public void Test() // Hver avdeling skal dukke opp, kun én instans per avdeling
        {
            foreach(var department in Departments.DepartmentList)
            {
                Console.WriteLine(department.Name);
            }
        }
    }
}
