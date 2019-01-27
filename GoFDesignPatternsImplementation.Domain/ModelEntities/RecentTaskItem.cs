/// <summary>
/// The Adapter Pattern
/// </summary>
namespace GoFDesignPatternsImplementation.Domain.ModelEntities
{
    using GoFDesignPatternsImplementation.Domain.BusinessServices;
    using System;
    public class RecentTaskItem : TaskItem, ITaskItem
    {
        public RecentTaskItem() { }
        public RecentTaskItem(MainTaskContainer container) : base(container) { }
        public bool IsTaskActiveAndRecent(uint timestamp)
        {
            return
            this.IsTaskActive() &&
            this.CreationDate.Ticks >= DateTime.Now.AddTicks(timestamp * -1).Ticks;
        }
    }
}
