using GoFDesignPatternsImplementation.Domain.ModelEntities;
using GoFDesignPatternsImplementation.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoFDesignPatternsImplementation.Domain.BusinessServices
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository repository;

        public TaskService(ITaskRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ITaskItemBase> GetTask(uint id)
        {
            return (await this.repository.GeAll()).Select(t => new RecentTaskItem
            {
                CreationDate = t.CreationDate,
                Status = t.Status,
                TaskId = t.TaskId,
                TaskTitle = t.TaskTitle
            }).FirstOrDefault(t => t.TaskId == id);
        }

        public async Task<IEnumerable<ITaskItemBase>> GetTasks()
        {
            return await this.repository.GeAll();
        }

        public async Task UpdateTask(ITaskItemBase model)
        {
            await this.repository.Update(model);
        }

        public async Task<ITaskItemBase> CloneTask(uint id, ITaskItemBase newItem)
        {
            var entity = await this.repository.Get(id);
            ITaskItemBase task = entity.Clone();
            task.TaskData = newItem.TaskData;

            return task;
        }
    }
}