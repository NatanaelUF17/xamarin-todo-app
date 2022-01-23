using System;
using ToDo.Models;
using ToDo.ViewModels.Helpers;

namespace ToDo.ViewModels
{
    // This viewmodel is for the todo item view
    public class TodoItemViewModel : ViewModel
    {
        public TodoItem Todo { get; private set; }

        public TodoItemViewModel(TodoItem todo)
        {
            Todo = todo;
        }

        public event EventHandler TodoStatusChanged;
        public string StatusText => Todo.IsCompleted ? "Reactivate" : "Completed";
    }
}
