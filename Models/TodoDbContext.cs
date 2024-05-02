using Microsoft.EntityFrameworkCore;

namespace To_Do_List_API.Models
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
            
        }

        public DbSet<TodoEntry> TodoEntries { get; set; }     
        public DbSet<TodoTag> TodoTags { get; set; }
        //public DbSet<User> Users { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TodoEntry>()
                .HasMany(e => e.Tags)
                .WithMany(e => e.TagEntries);   
        }
    }
}
