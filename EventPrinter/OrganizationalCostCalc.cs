using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPrinter
{
    class OrganizationalCostCalc
    {
        private readonly Teams _teams;
        private readonly Departments _departments;

        public OrganizationalCostCalc(Teams teams, Departments departments)
        {
            _teams = teams;
            _departments = departments;
        }

        public void SumTeamCost()
        {
            for(int i = 0; i < _teams.TeamList.Count; i++)
            {
                Team team = _teams.TeamList[i];
                team.SumTeamCost();
            }
        }

        public void SumDepartmentCost()
        {
            for (int i = 0; i < _departments.DepartmentList.Count; i++)
            {
                Department department = _departments.DepartmentList[i];
                department.SumDepartmentCost();
            }
        }
    }
}
