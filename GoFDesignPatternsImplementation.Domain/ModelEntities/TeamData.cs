using System.Collections.Generic;

namespace GoFDesignPatternsImplementation.Domain.ModelEntities
{
    public class TeamData
    {
        public TeamData()
        {
            this.TeamMembers = new Dictionary<string, ITeamMember>();
        }
        public string TeamName { get; set; }

        public Dictionary<string, ITeamMember> TeamMembers { get; set; }
    }
}