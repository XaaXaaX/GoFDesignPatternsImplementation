namespace GoFDesignPatternsImplementation.Domain.ModelEntities
{
    public interface ITaskItem
    {
        bool IsTaskActiveAndRecent(uint timestamp);
    }
}