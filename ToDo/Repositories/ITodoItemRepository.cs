using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo.Repositories
{
    public interface ITodoItemRepository
    {
        event EventHandler<TodoItem> OnTodoAdded;
        event EventHandler<TodoItem> OnTodoUpdated;
        event EventHandler<TodoItem> OnTodoRemoved;

        Task<List<TodoItem>> GetTodos();
        Task AddTodo(TodoItem todo);
        Task UpdateTodo(TodoItem todo);
        Task RemoveTodo(TodoItem todo);
        Task AddOrUpdate(TodoItem todo);
    }
}
