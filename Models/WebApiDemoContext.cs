using Microsoft.EntityFrameworkCore;

namespace To_Do_List_API.Models
{
    public class WebApiDemoContext : DbContext
    {
        public WebApiDemoContext(DbContextOptions<WebApiDemoContext> options) : base(options)
        {
            
        }

        public DbSet<TodoEntry> TodoEntries { get; set; }     
        public DbSet<TodoTag> TodoTags { get; set; }
        public DbSet<User> Users { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoEntry>()
                .HasOne(u => u.User)
                .WithMany()
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<TodoEntry>()
                .HasMany(t => t.Tags)
                .WithMany(t => t.TagEntries);   
        }
    }
}
