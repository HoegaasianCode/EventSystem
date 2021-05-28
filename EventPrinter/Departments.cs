using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPrinter
{
    class Departments
    {
        public List<Department> DepartmentList { get; set; } = new();
        public Department[] DepartmentArray { get; set; }

        public void ToArray()
        {
            DepartmentArray = DepartmentList.ToArray();
        }
    }
}
