namespace GoFDesignPatternsImplementation.Infrastructure.Entities
{
    internal enum TastStatusEntity: byte
    {
        Unknown,
        Rehected,
        Abandoned,
        Ready,
        InProgress,
        Validation,
        Validated,
        Terminated
    }
}