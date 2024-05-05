using System.ComponentModel.DataAnnotations;

namespace To_Do_List_API.Models
{
    public class TodoEntry
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsDone { get; set; }
        public List<TodoTag> Tags { get; set; }

        public TodoEntry() {
            Id = Guid.NewGuid();
            Title = string.Empty;
            CreateDate = DateTime.Now;
            UpdateDate = CreateDate;
            IsDone = false;
            Tags = [];
        }
        public TodoEntry(string title, List<TodoTag> tags, string? description = null, DateTime? dueDate = null)
        {   
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            CreateDate = DateTime.Now;
            UpdateDate = CreateDate;
            DueDate = dueDate;
            IsDone = false;
            Tags = tags;
        }

        public TodoEntry(TodoEntry entry)
        {
            Id = entry.Id;
            Title = entry.Title;
            Description = entry.Description;
            CreateDate = entry.CreateDate;
            UpdateDate = entry.UpdateDate;
            DueDate = entry.DueDate;
            IsDone = entry.IsDone;
            Tags = entry.Tags;
        }
    }
}