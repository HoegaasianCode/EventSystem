using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPrinter
{
    class EventOrganizer
    {
        private List<string[]> employmentEvents = new();
        private List<string[]> costEvents = new();
        private List<string[]> organizationalEvents = new();
        public string[][] EmploymentEvents { get; set; }
        public string[][] CostEvents { get; set; }
        public string[][] OrganizationalEvents { get; set; }

        public void FilterEvents(string[] lineArray)
        {
            if (lineArray[0].ToLower().Contains("ans")) employmentEvents.Add(lineArray);
            if (lineArray[0].ToLower().Contains("byttet")) organizationalEvents.Add(lineArray);
            if (lineArray[0].ToLower().Contains("lønn") || lineArray[0].ToLower().Contains("stillings") 
                || lineArray[0].ToLower().Contains("sluttet")) costEvents.Add(lineArray);
        }

        public void ToArrayArray()
        {
            EmploymentEvents = employmentEvents.ToArray();
            CostEvents = costEvents.ToArray();
            OrganizationalEvents = organizationalEvents.ToArray();
            NullifyLists();
        }

        private void NullifyLists()
        {
            employmentEvents = costEvents = organizationalEvents = null;
        }

        public void Test()
        {
            foreach(var x in CostEvents)
            {
                Console.WriteLine(x[0]);
            }
        }
    }
}
