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
        private readonly WebApiDemoContext _context;
        private readonly TodoService _todoService;

        public TodoEntryController(ILogger<TodoEntryController> logger, WebApiDemoContext context, TodoService todoService)
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
        public ActionResult Get([FromRoute] Guid id)
        {
            var entry = _context.TodoEntries.FirstOrDefault(e => e.Id == id);
            if (entry == null)
            {
                return NotFound();
            }
            return Ok(entry);
        }

        [HttpPost]
        public ActionResult Post([FromBody] TodoEntryViewModel entry)
        {
            TodoEntry newEntry = new TodoEntry(entry.Title, entry.Description, entry.DueDate);
            _context.TodoEntries.Add(newEntry);
            _context.SaveChanges();
            return Created("", newEntry);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] Guid id)
        {
            var entry = _context.TodoEntries.FirstOrDefault(e => e.Id == id);
            if (entry == null)
            {
                return NotFound();
            }
            _context.TodoEntries.Remove(entry);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromRoute] Guid id, [FromBody] TodoEntryViewModel entry)
        {
            var existingEntry = _context.TodoEntries.FirstOrDefault(e => e.Id == id);
            if (existingEntry == null)
            {
                return NotFound();
            }
            existingEntry.Title = entry.Title;
            existingEntry.Description = entry.Description;
            existingEntry.DueDate = entry.DueDate;
            existingEntry.UpdateDate = DateTime.Now;
            _context.SaveChanges();
            return Ok(existingEntry);
        }
    }
}
