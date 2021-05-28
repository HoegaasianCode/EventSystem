using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPrinter
{
    class TeamFactory
    {
        private readonly string[][] _lineArrayArray;
        public Teams Teams { get; }

        public TeamFactory(string[][] lineArrayArray, Teams teams)
        {
            _lineArrayArray = lineArrayArray;
            Teams = teams;
        }

        public void CollectAllTeamStrings()
        {
            List<string> stringList = new();
            for (int i = 0; i < _lineArrayArray.Length; i++)
            {
                string[] lineArray = _lineArrayArray[i];
                for (int j = 0; j < lineArray.Length; j++)
                {
                    stringList.Add(lineArray[7]);
                }
            }
            IsExistingTeam(stringList);
        }

        private void IsExistingTeam(List<string> stringList)
        {
            string[] distinctStringArray = stringList.Distinct().ToArray();
            for (int i = 0; i < distinctStringArray.Length; i++)
            {
                string distinctString = distinctStringArray[i];
                bool isUnique = true;
                for (int j = 0; j < Teams.TeamList.Count; j++)
                {
                    Team team = Teams.TeamList[j];
                    if (distinctString == team.Name) isUnique = false;
                }
                if (isUnique) NewTeam(distinctString);
            }
            Teams.ToArray();
        }

        private void NewTeam(string uniqueString)
        {
            Team team = new(uniqueString);
            Teams.TeamList.Add(team);
        }

        public void Test() // Hvert team skal dukke opp, kun én instans per team
        {
            foreach(var team in Teams.TeamList)
            {
                Console.WriteLine(team.Name);
            }
        }
    }
}

