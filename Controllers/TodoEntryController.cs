using Microsoft.AspNetCore.Mvc;
using System.Linq;
using To_Do_List_API.Models;

namespace To_Do_List_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoEntryController : ControllerBase
    {
        private readonly ILogger<TodoEntryController> _logger;
        private readonly WebApiDemoContext _context;

        
        
        public TodoEntryController(ILogger<TodoEntryController> logger, WebApiDemoContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_context.ToDoItem.ToList());
        }

        [HttpPost]
        public ActionResult Post([FromBody] TodoEntryViewModel entry)
        {
            TodoEntry newEntry = new TodoEntry(entry.Title, entry.Description, entry.DueDate);
            _context.ToDoItem.Add(newEntry);
            return Created("U don't have to know :)", newEntry);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] Guid id)
        {
            var entry = _context.ToDoItem.FirstOrDefault(e => e.Id == id);
            if (entry == null)
            {
                return NotFound();
            }
            _context.ToDoItem.Remove(entry);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromRoute] Guid id, [FromBody] TodoEntryViewModel entry)
        {
            var existingEntry = _context.ToDoItem.FirstOrDefault(e => e.Id == id);
            if (existingEntry == null)
            {
                return NotFound();
            }
            existingEntry.Title = entry.Title;
            existingEntry.Description = entry.Description;
            existingEntry.DueDate = entry.DueDate;
            return Ok(existingEntry);
        }
    }
}
