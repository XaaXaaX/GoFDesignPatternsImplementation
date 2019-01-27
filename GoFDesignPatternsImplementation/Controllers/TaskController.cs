namespace GoFDesignPatternsImplementation.Controllers
{
    using GoFDesignPatternsImplementation.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using GoFDesignPatternsImplementation.Domain.BusinessServices;
    using GoFDesignPatternsImplementation.Domain.ModelEntities;

    /// <summary>
    /// The Bridge Pattern
    /// The Task Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {

        private readonly ITaskService service;

        /// <summary>
        /// Create a new instance of Task Controller
        /// </summary>
        /// <param name="service"></param>
        public TaskController(ITaskService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Gets a list of Tasks
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpHead]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TaskItem>))]
        [ProducesResponseType(404)]
        public async Task<IEnumerable<TaskModel>> GetTaskItems()
        {
            return
                (await service.GetTasks()).Select(m => (TaskModel)(m as TaskItem));
        }

        [Route("{id}/recent/{timestamp}")]
        [HttpHead]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> IsTaskRecent([FromRoute]uint id, [FromRoute]uint timestamp)
        {
            var task = await this.service.GetTask(id);

            if ((task as RecentTaskItem).IsTaskActiveAndRecent(timestamp))
                return Ok();

            return this.ValidationProblem();
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateTask([FromBody]TaskModel model)
        {
            if (ModelState.IsValid)
            {
                TaskItem item = model;
                await this.service.UpdateTask(item);
                return Ok();
            }

            return this.ValidationProblem();
        }
        [Route("clone/{id}")]
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CloneTask([FromRoute]uint id, [FromBody]TaskModel model)
        {
            TaskItem tsk = model;
            return Ok(await this.service.CloneTask(id, tsk));
        }

    }
}