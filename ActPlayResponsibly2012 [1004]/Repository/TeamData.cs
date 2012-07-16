using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActPlayResponsibly2012.Repository
{
    public class TeamData
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string AvatarPath { get; set; }
        public string BackgroundPath { get; set; }
        public List<int[]> Path { get; set; }
    }

    public class TeamDataCollection
    {
        public TeamData RedTeam { get; set; }
        public TeamData YellowTeam { get; set; }
        public TeamData GreenTeam { get; set; }
        public TeamData BlueTeam { get; set; }
    }
}
