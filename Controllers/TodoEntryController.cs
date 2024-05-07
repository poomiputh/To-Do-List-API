using Microsoft.AspNetCore.Mvc;
using To_Do_List_API.Models;
using To_Do_List_API.ViewModels;
using To_Do_List_API.Services;

namespace To_Do_List_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoEntryController : ControllerBase
    {
        private readonly ILogger<TodoEntryController> _logger;
        private readonly TodoDbContext _context;
        private readonly TodoService _todoService;

        public TodoEntryController(ILogger<TodoEntryController> logger, TodoDbContext context, TodoService todoService)
        {
            _logger = logger;
            _context = context;
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _todoService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get([FromRoute] Guid id)
        {
            return Ok(await _todoService.GetById(id));
        }

        [HttpGet("searchDateTime")]
        public async Task<ActionResult> Get([FromQuery] DateTime startDateTime, [FromQuery] DateTime endDateTime)
        {
            return Ok(await _todoService.GetByDateTime(startDateTime, endDateTime));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TodoEntryViewModel entry)
        {
            _logger.LogDebug(entry.Title);
            bool status = await _todoService.AddTodo(new TodoEntry(entry.Title, entry.Tags, entry.Description, entry.DueDate));
            if (status)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            bool status = await _todoService.RemoveTodo(id);
            if (status)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] TodoEntryViewModel entry)
        {
           bool status = await _todoService.UpdateTodo(id, entry);
           if (status)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
