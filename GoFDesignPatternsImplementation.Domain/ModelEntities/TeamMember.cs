namespace GoFDesignPatternsImplementation.Domain.ModelEntities
{
    public class TeamMember : ITeamMember
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NikeName { get; set; }
        public string Email { get; set; }
    }

    public class TeamLeader : ITeamMember
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NikeName { get; set; }
        public string Email { get; set; }
    }
}