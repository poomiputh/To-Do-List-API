﻿using To_Do_List_API.Models;

namespace To_Do_List_API
{
    public class TodoEntry
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime? DueDate { get; set; }

        public List<TodoTag>? Tags { get; set; }

        public TodoEntry(string title, string? description = null, DateTime? dueDate = null)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            DueDate = dueDate;
        }

        public TodoEntry(TodoEntry entry)
        {
            Id = entry.Id;
            Title = entry.Title;
            Description = entry.Description;
            CreateDate = entry.CreateDate;
            UpdateDate = entry.UpdateDate;
            DueDate = entry.DueDate;
        }
    }
}