using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HomeTask.Domain;

namespace HomeTask.Services
{
    public interface ITodoService
    {
        Task<List<TodoItem>> GetAllAsync();
        Task<bool> CreateAsync(TodoItem post);

        Task<TodoItem> GetByIdAsync(int todoId);

        Task<bool> UpdateAsync(TodoItem postToUpdate);

        Task<bool> DeleteAsync(int todoId);
        
    }
}