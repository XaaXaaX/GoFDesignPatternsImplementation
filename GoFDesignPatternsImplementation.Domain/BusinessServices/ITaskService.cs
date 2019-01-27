using GoFDesignPatternsImplementation.Domain.ModelEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoFDesignPatternsImplementation.Domain.BusinessServices
{
    public interface ITaskService
    {
        Task<IEnumerable<ITaskItemBase>> GetTasks();
        Task<ITaskItemBase> GetTask(uint id);
        Task UpdateTask(ITaskItemBase model);
        Task<ITaskItemBase> CloneTask(uint id, ITaskItemBase newTask);
    }
}