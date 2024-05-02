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

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TodoEntryViewModel entry)
        {
            bool status = await _todoService.AddTodo(new TodoEntry(entry.Title, entry.Description, entry.DueDate));
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

        //[HttpPut("{id}")]
        //public ActionResult Put([FromRoute] Guid id, [FromBody] TodoEntryViewModel entry)
        //{
        //    var existingEntry = _context.TodoEntries.FirstOrDefault(e => e.Id == id);
        //    if (existingEntry == null)
        //    {
        //        return NotFound();
        //    }
        //    existingEntry.Title = entry.Title;
        //    existingEntry.Description = entry.Description;
        //    existingEntry.DueDate = entry.DueDate;
        //    existingEntry.UpdateDate = DateTime.Now;
        //    _context.SaveChanges();
        //    return Ok(existingEntry);
        //}
    }
}
