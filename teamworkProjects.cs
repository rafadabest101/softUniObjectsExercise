namespace softUniClassesExc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            List<Team> printedTeams = new List<Team>();

            int n = int.Parse(Console.ReadLine());
            for(int i = 1; i <= n; i++)
            {
                string[] details = Console.ReadLine().Split('-').ToArray();
                string creator = details[0];
                string teamName = details[1];

                bool hasTeamWithTeamName = false;
                bool hasTeamMadeByUser = false;
                if(teams.Count > 0)
                {
                    foreach(Team team in teams)
                    {
                        if(team.TeamName == teamName) hasTeamWithTeamName = true;
                        if(team.Creator == creator) hasTeamMadeByUser = true;
                    }
                }
                if(hasTeamWithTeamName) Console.WriteLine($"Team {teamName} was already created!");
                else if(hasTeamMadeByUser) Console.WriteLine($"{creator} cannot create another team!");
                else
                {
                    teams.Add(new Team(teamName, creator));
                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }
            }

            string joinCommand = Console.ReadLine();
            while(joinCommand != "end of assignment")
            {
                string[] details = joinCommand.Split("->").ToArray();
                string member = details[0];
                string teamName = details[1];

                bool teamExists = false;
                bool memberIsInAnotherTeam = false;
                foreach(Team team in teams)
                {
                    if(team.TeamName == teamName) teamExists = true;
                    if(team.Members.Contains(member) || member == team.Creator) memberIsInAnotherTeam = true;
                }
                if(!teamExists) Console.WriteLine($"Team {teamName} does not exist!");
                else
                {
                    foreach(Team team in teams)
                    {
                        if(team.TeamName == teamName)
                        {
                            if(memberIsInAnotherTeam) Console.WriteLine($"Member {member} cannot join team {teamName}!");
                            else team.Members.Add(member);
                        }
                    }
                }
                joinCommand = Console.ReadLine();
            }

            List<Team> leftTeams = teams.Where(t => t.Members.Count > 0).ToList();
            List<Team> disbandTeams = teams.Where(t => t.Members.Count <= 0).ToList();

            List<Team> orderedLeftTeams = leftTeams
                .OrderByDescending(t => t.Members.Count)
                .ThenBy(t => t.TeamName)
                .ToList();
            orderedLeftTeams.ForEach(team => Console.WriteLine(team));

            List<Team> orderedDisbandTeams = disbandTeams.OrderBy(t => t.TeamName).ToList();
            Console.WriteLine("Teams to disband:");
            orderedDisbandTeams.ForEach(team => Console.WriteLine(team.TeamName));
        }
    }

    class Team
    {
        public string TeamName { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }

        public Team(string teamName, string creator)
        {
            TeamName = teamName;
            Creator = creator;
            Members = new List<string>();
        }
        public override string ToString()
        {
            return $"{TeamName}\n"
                + $"- {Creator}\n"
                + $"{GetMembersString()}";
        }

        public string GetMembersString()
        {
            Members = Members.OrderBy(name => name).ToList();

            string result = "";

            for(int i = 0; i < Members.Count - 1; i++)
            {
                result += $"-- {Members[i]}\n";
            }

            result += $"-- {Members[Members.Count - 1]}";
            return result;
        }
    }
}