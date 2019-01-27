using System;
using System.Collections.Generic;
using GoFDesignPatternsImplementation.Domain.Enums;
using System.Linq;

namespace GoFDesignPatternsImplementation.Domain.ModelEntities
{
    [Serializable]
    public class MainTaskContainer : ITaskItemBase
    {
        readonly IDictionary<uint, ITaskItemBase> TaskList;

        public MainTaskContainer() : this(new Dictionary<uint, ITaskItemBase>()) { }

        public MainTaskContainer(IDictionary<uint, ITaskItemBase> TaskList) => this.TaskList = TaskList;

        public delegate void CallBack(FlowStatus status);

        public event CallBack UpdateTasks;

        public uint TaskId { get; set; }

        public string TaskTitle { get; set; }

        public FlowStatus Status { get; set; }

        public TaskMetaData TaskData { get; set; }

        public DateTime CreationDate { get; set; }

        public void Update(FlowStatus status)
        {
            this.Status = status;
            TaskList.AsParallel().ForAll(t => t.Value.Update(status));
        }

        ITaskItemBase ITaskItemBase.Clone() => throw new NotSupportedException();

        public bool IsTaskActive() =>
                this.Status != FlowStatus.Abandoned &&
                this.Status != FlowStatus.Rejected &&
                this.Status != FlowStatus.Unknown;

        public void UpdateStatus(FlowStatus status)
        {
            Update(status);
            UpdateTasks(status);
        }
    }
}
