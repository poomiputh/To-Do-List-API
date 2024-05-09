using Microsoft.EntityFrameworkCore;
using To_Do_List_API.Models;
using To_Do_List_API.ViewModels;

namespace To_Do_List_API.Services
{
    public class TodoService
    {
        private readonly ILogger<TodoService> _logger;
        private readonly TodoDbContext _context;

        public TodoService(ILogger<TodoService> logger, TodoDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<List<TodoEntry>> GetAll()
        {
            return await _context.TodoEntries.ToListAsync();
        }

        public async Task<TodoEntry?> GetById(Guid id)
        {
            return await _context.TodoEntries.FindAsync(id);
        }

        public async Task<bool> AddTodo(TodoEntry entry)
        {
            if (entry == null) { return false; }

            var tags = new List<TodoTag>();
            foreach (var tag in entry.Tags)
            {
                var existingTag = await _context.TodoTags.FirstOrDefaultAsync(t => t.Name == tag.Name);
                if (existingTag != null)
                {
                    tags.Add(existingTag);
                }
                else
                {
                    var newTag = new TodoTag { Name = tag.Name };
                    await _context.TodoTags.AddAsync(newTag);
                    tags.Add(newTag);
                }
            }

            entry.Tags = tags;
            await _context.TodoEntries.AddAsync(entry);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveTodo(Guid id)
        {
            var todo = await GetById(id);
            if (todo == null) { return false; }
            else
            {
                _context.TodoEntries.Remove(todo);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> UpdateTodo(Guid id, TodoEntryViewModel entry)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            TodoEntry? existingTodo = await GetById(id);
            if (existingTodo == null)
            {
                return false;
            }

            existingTodo.Title = entry.Title;
            existingTodo.Description = entry.Description;
            existingTodo.DueDate = entry.DueDate;
            existingTodo.IsDone = entry.IsDone;

            if (entry.Tags.Count > 0)
            {
                foreach (var tag in entry.Tags)
                {
                    var existingTag = await _context.TodoTags.FirstOrDefaultAsync(t => t.Name == tag.Name);
                    if (existingTag == null)
                    {
                        await _context.TodoTags.AddAsync(tag);
                        existingTodo.Tags.Add(tag);
                    }
                }
            }

            try
            {
                _context.Update(existingTodo);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Update Todo Failed, Message: {error}", ex);
                return false;
            }
        }

        public async Task<List<TodoEntry>> GetByDateTime(DateTime startDateTime, DateTime endDateTime)
        {
            _logger.LogInformation("Searching for Todo Entries between {startDateTime} and {endDateTime}", startDateTime, endDateTime);
            var results = await _context.TodoEntries
            .Include(todo => todo.Tags)
            .Where(todo => todo.DueDate >= startDateTime && todo.DueDate <= endDateTime)
            .OrderBy(todo => todo.DueDate)
            .ToListAsync();
            return results;
        }
    }
}
