using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApp.Application.DTOs;
using TaskManagementApp.Application.Features.Tasks.Commands.CreateTask;
using TaskManagementApp.Application.Features.Tasks.Commands.DeleteTask;
using TaskManagementApp.Application.Features.Tasks.Commands.UpdateTask;
using TaskManagementApp.Application.Features.Tasks.Queries.GetAllTasks;
using TaskManagementApp.Application.Features.Tasks.Queries.GetTaskById;

namespace TaskManagementApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskDTO>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllTasksQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDTO>> GetById(int id)
        {
            var result = await _mediator.Send(new GetTaskByIdQuery(id));
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateTaskDTO dto)
        {
            var id = await _mediator.Send(new CreateTaskCommand(dto));
            return CreatedAtAction(nameof(GetById), new {id}, null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] CreateTaskDTO dto)
        {
            var updateResult = await _mediator.Send(new UpdateTaskCommand(id, dto));
            return CreatedAtAction(nameof(Update), new { updateResult }, null);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var success = await _mediator.Send(new DeleteTaskCommand(id));
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
