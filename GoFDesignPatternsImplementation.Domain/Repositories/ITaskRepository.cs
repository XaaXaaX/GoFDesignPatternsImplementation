namespace GoFDesignPatternsImplementation.Domain.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using GoFDesignPatternsImplementation.Domain.ModelEntities;
    public interface ITaskRepository
    {
        Task<ITaskItemBase> Get(uint id);
        Task<IEnumerable<ITaskItemBase>> GeAll();
        Task Update(ITaskItemBase model);
    }
}