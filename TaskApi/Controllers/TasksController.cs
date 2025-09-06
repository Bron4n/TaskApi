using Microsoft.AspNetCore.Mvc;
using TaskApi.Contracts;
using TaskApi.Services;

namespace TaskApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _service;

        public TasksController(ITaskService service)
        {
            _service = service;
        }

        // GET /api/tasks
        [HttpGet]
        public ActionResult<IEnumerable<TaskDto>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        // GET /api/tasks/{id}
        [HttpGet("{id}")]
        public ActionResult<TaskDto> GetById(Guid id)
        {
            var task = _service.GetById(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        // POST /api/tasks
        [HttpPost]
        public ActionResult<TaskDto> Create(CreateTaskDto dto)
        {
            try
            {
                var created = _service.Create(dto);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // PUT /api/tasks/{id}
        [HttpPut("{id}")]
        public ActionResult<TaskDto> Update(Guid id, UpdateTaskDto dto)
        {
            try
            {
                var updated = _service.Update(id, dto);
                if (updated == null) return NotFound();
                return Ok(updated);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // DELETE /api/tasks/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var deleted = _service.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
