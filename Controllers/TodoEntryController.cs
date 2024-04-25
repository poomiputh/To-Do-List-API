using Microsoft.AspNetCore.Mvc;

namespace To_Do_List_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoEntryController : ControllerBase
    {
        private static List<TodoEntry> _todoEntries = new List<TodoEntry>();
        
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Hello World!");
        }

        [HttpPost]
        public ActionResult Post([FromBody] TodoEntry entry)
        {
            _todoEntries.Add(entry);
            return Created($"/{entry.Id}", entry);
        }
    }
}
