using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace To_Do_List_API.Models
{
    public class TodoTag
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<TodoEntry> TagEntries { get; set; }

        public TodoTag()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
            TagEntries = [];
        }

        public TodoTag(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            TagEntries = [];
        }
    }
}
