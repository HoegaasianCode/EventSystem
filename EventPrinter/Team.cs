using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPrinter
{
    class Team
    {
        public string Name;
        public List<Employee> Members { get; set; }
        public Department Department { get; set; }
        public double Cost { get; set; }

        public Team(string name)
        {
            Name = name;
            Members = new();
            Cost = 0;
        }

        public void RemoveMember(Employee employee)
        {
            Members.Remove(employee);
        }

        public void AddMember(Employee member)
        {
            Members.Add(member);
        }

        public void SumTeamCost()
        {
            for (int i = 0; i < Members.Count; i++)
            {
                Employee member = Members[i];
                Cost += member.Cost;
            }
        }
    }
}
