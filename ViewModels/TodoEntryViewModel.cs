using To_Do_List_API.Models;

namespace To_Do_List_API.ViewModels
{
    public class TodoEntryViewModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsDone { get; set; }
        public List<TodoTag> Tags { get; set;}

        public TodoEntryViewModel()
        {
            Title = string.Empty;
            IsDone = false;
            Tags = [];
        }
    }
}