using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPrinter
{
    class Teams
    {
        public List<Team> TeamList { get; set; } = new();
        public Team[] TeamArray { get; set; }

        public void ToArray()
        {
            TeamArray = TeamList.ToArray();
        }
    }
}
