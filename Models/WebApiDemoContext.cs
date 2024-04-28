using Microsoft.EntityFrameworkCore;

namespace To_Do_List_API.Models
{
    public class WebApiDemoContext : DbContext
    {
        public WebApiDemoContext(DbContextOptions<WebApiDemoContext> options) : base(options)
        {

        }

        public DbSet<TodoEntry> ToDoItem { get; set; }         
    }
}
