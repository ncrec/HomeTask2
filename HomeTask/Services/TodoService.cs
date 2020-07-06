using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HomeTask.Data;
using HomeTask.Domain;

namespace HomeTask.Services
{
    public class TodoService:ITodoService
    {
        private readonly DataContext _dataContext;

        public TodoService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<TodoItem> GetByIdAsync(int todoId)
        {
            return await _dataContext.TodoItems.SingleOrDefaultAsync(x => x.Id == todoId);

        }
        public async Task<List<TodoItem>> GetAllAsync()
        {
            return await _dataContext.TodoItems.ToListAsync();
        }
        public async Task<bool> CreateAsync(TodoItem todoItem)
        {
            await _dataContext.TodoItems.AddAsync(todoItem);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> UpdateAsync(TodoItem todoItemToUpdate)
        {
            _dataContext.TodoItems.Update(todoItemToUpdate);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }
        public async Task<bool> DeleteAsync(int todoItemID)
        {
            var post = await GetByIdAsync(todoItemID);

            if (post == null)
                return false;

            _dataContext.TodoItems.Remove(post);
            var deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0;
        }
    }
}