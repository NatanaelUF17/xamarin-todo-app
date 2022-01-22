using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using ToDo.Models;

namespace ToDo.Repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {
        public event EventHandler<TodoItem> OnTodoAdded;
        public event EventHandler<TodoItem> OnTodoUpdated;
        public event EventHandler<TodoItem> OnTodoRemoved;

        public SQLiteAsyncConnection dbConnection;

        public async Task AddOrUpdate(TodoItem todo)
        {
            if (todo.Id.Equals(0))
            {
                await AddTodo(todo);
            }
            await UpdateTodo(todo);
        }

        public async Task<List<TodoItem>> GetTodos()
        {
            await CreateConnection();
            return await dbConnection.Table<TodoItem>().ToListAsync();
        }

        public async Task AddTodo(TodoItem todo)
        {
            await CreateConnection();
            await dbConnection.InsertAsync(todo);
            OnTodoAdded?.Invoke(this, todo);
        }

        public async Task UpdateTodo(TodoItem todo)
        {
            await CreateConnection();
            await dbConnection.UpdateAsync(todo);
            OnTodoUpdated?.Invoke(this, todo);
        }

        public async Task RemoveTodo(TodoItem todo)
        {
            await CreateConnection();
            await dbConnection.DeleteAsync(todo);
            OnTodoRemoved?.Invoke(this, todo);
        }

        private async Task CreateConnection()
        {
            if (dbConnection != null)
            {
                return;
            }

            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var databasePath = Path.Combine(documentPath, "Todos.db");

            dbConnection = new SQLiteAsyncConnection(databasePath);
            await dbConnection.CreateTableAsync<TodoItem>();

            if (await dbConnection.Table<TodoItem>().CountAsync() == 0)
            {
                await dbConnection.InsertAsync(new TodoItem
                {
                    Title = "Learning Xamarin Forms",
                    IsCompleted = false,
                    Due = DateTime.Now
                });
            }
        }
    }
}
