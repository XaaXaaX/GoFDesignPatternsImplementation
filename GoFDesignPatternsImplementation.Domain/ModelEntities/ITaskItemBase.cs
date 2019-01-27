using System;
using GoFDesignPatternsImplementation.Domain.Enums;

namespace GoFDesignPatternsImplementation.Domain.ModelEntities
{
    public interface ITaskItemBase
    {
        DateTime CreationDate { get; set; }
        FlowStatus Status { get; set; }
        TaskMetaData TaskData { get; set; }
        uint TaskId { get; set; }
        string TaskTitle { get; set; }
        bool IsTaskActive();
        void Update(FlowStatus status);
        ITaskItemBase Clone();
    }
}