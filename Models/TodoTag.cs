using System.ComponentModel.DataAnnotations;

namespace To_Do_List_API.Models
{
    public class TodoTag
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1)]
        [RegularExpression("^\\w+$", MatchTimeoutInMilliseconds = 1000)]
        public string Name { get; set; } = string.Empty;

        public List<TodoEntry> TagEntries { get; set; } = [];
    }
}
