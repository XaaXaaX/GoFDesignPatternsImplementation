namespace GoFDesignPatternsImplementation.Domain.ModelEntities
{
    using GoFDesignPatternsImplementation.Domain.DomainTraversalModels;
    using GoFDesignPatternsImplementation.Domain.Enums;
    using System;

    [Serializable]
    public class TaskItem : Prototype<TaskItem>, ITaskItemBase
    {
        public MainTaskContainer container { get; }
        public TaskItem() { }
        public TaskItem(MainTaskContainer container)
        {
            this.container = container;
            this.container.UpdateTasks += Update;
        }
        
        public uint TaskId { get; set; }

        public TaskMetaData TaskData { get; set; }

        public string TaskTitle { get; set; }

        public DateTime CreationDate { get; set; }

        public FlowStatus Status { get; set; }

        public bool IsTaskActive()
        {
            return
                this.Status != FlowStatus.Abandoned &&
                this.Status != FlowStatus.Rejected &&
                this.Status != FlowStatus.Unknown;
        }

        public void Update(FlowStatus status)
        {
            Status = status;
        }

        ITaskItemBase ITaskItemBase.Clone()
        {
            return this.Clone();
        }
    }
}