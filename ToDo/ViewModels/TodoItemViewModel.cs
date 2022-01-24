using System;
using System.Windows.Input;
using ToDo.Models;
using ToDo.ViewModels.Helpers;
using Xamarin.Forms;

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

        public ICommand ToggleCompleted => new Command((arg) =>
        {
            Todo.IsCompleted = !Todo.IsCompleted;
            TodoStatusChanged?.Invoke(this, new EventArgs());
        });
    }
}
