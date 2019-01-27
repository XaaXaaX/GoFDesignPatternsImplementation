namespace GoFDesignPatternsImplementation.Domain.ModelEntities
{
    public interface ITeamMember
    {
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string NikeName { get; set; }
    }
}