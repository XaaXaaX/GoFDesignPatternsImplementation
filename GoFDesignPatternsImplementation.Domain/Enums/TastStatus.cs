namespace GoFDesignPatternsImplementation.Domain.Enums
{
    public enum FlowStatus : byte
    {
        Unknown,
        Ready,
        InProgress,
        Validation,
        Validated,
        Terminated,
        Rejected,
        Abandoned
    }
}