using System;
using ToDo.Models;
using ToDo.ViewModels.Helpers;

namespace ToDo.ViewModels
{
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
