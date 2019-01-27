namespace GoFDesignPatternsImplementation.Infrastructure.Repositories
{
    using GoFDesignPatternsImplementation.Domain.ModelEntities;
    using GoFDesignPatternsImplementation.Domain.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;

    public class TaskRepository : ITaskRepository
    {
        private static Collection<TaskItem> taskItems;

        public TaskRepository()
        {
            taskItems = GetFakeData();
        }

        public async Task<ITaskItemBase> Get(uint id)
        {
            return taskItems.SingleOrDefault(t => t.TaskId == id);
        }

        public async Task<IEnumerable<ITaskItemBase>> GeAll()
        {
            return taskItems;
        }

        public async Task Update(ITaskItemBase model)
        {
            var task = taskItems.SingleOrDefault(t => t.TaskId == model.TaskId);
            task = model as TaskItem;
        }

        private static Collection<TaskItem> GetFakeData()
        {
            taskItems = new Collection<TaskItem>
                {
                    new TaskItem
                    {
                        TaskId = 1, TaskTitle = "AAAA", CreationDate= DateTime.Now, Status = Domain.Enums.FlowStatus.Unknown,
                        TaskData = new TaskMetaData{ Priority = Priority.Low, Team = new TeamData{ TeamName = "TeamA"  } }
                    },
                    new TaskItem
                    {
                        TaskId = 2, TaskTitle = "BBBB" , Status= Domain.Enums.FlowStatus.Ready, CreationDate= DateTime.Now.AddDays(-2),
                        TaskData = new TaskMetaData{ Priority = Priority.Normal, Team = new TeamData{ TeamName = "TeamB"  } }
                    }
                };

            return taskItems;
        }
    }
}
