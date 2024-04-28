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

        private static List<TodoEntry> _todoEntries = new List<TodoEntry>();
        
        public TodoEntryController(ILogger<TodoEntryController> logger, WebApiDemoContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_todoEntries);
        }

        [HttpPost]
        public ActionResult Post([FromBody] TodoEntryViewModel entry)
        {
            TodoEntry newEntry = new TodoEntry(entry.Title, entry.Description, entry.DueDate);
            _todoEntries.Add(newEntry);
            return Created("U don't have to know :)", newEntry);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] Guid id)
        {
            var entry = _todoEntries.FirstOrDefault(e => e.Id == id);
            if (entry == null)
            {
                return NotFound();
            }
            _todoEntries.Remove(entry);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromRoute] Guid id, [FromBody] TodoEntryViewModel entry)
        {
            var existingEntry = _todoEntries.FirstOrDefault(e => e.Id == id);
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
