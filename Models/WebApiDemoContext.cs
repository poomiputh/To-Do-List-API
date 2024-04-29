using Microsoft.EntityFrameworkCore;

namespace To_Do_List_API.Models
{
    public class WebApiDemoContext : DbContext
    {
        public WebApiDemoContext(DbContextOptions<WebApiDemoContext> options) : base(options)
        {
            
        }

        public DbSet<TodoEntry> ToDoItem { get; set; }     
        public DbSet<TodoTag> ToDoTag { get; set; }

        public DbSet<User> User { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoEntry>().ToTable("TodoEntry")
                .HasMany(t => t.Tags)
                .WithMany(t => t.TagEntries);

            modelBuilder.Entity<TodoTag>().ToTable("TodoTag");
           
        }
    }
}
