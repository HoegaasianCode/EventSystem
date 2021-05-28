using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPrinter
{
    struct LineReader
    {
        public EventOrganizer EventOrganizer { get; set; }

        public void ReadLines()
        {
            using StreamReader sr = new("TextFile1.txt");
            EventOrganizer eventOrganizer = new();
            while (true)
            {
                string line = sr.ReadLine();
                if (line == null) break;
                string[] lineArray = line.Split(",");
                eventOrganizer.FilterEvents(lineArray);
            }
            sr.Close();
            eventOrganizer.ToArrayArray();
            EventOrganizer = eventOrganizer;
        }
    }
}
