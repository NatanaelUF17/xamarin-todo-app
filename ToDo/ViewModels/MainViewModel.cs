using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDo.Models;
using ToDo.Repositories;
using ToDo.ViewModels.Helpers;
using ToDo.Views;
using Xamarin.Forms;

namespace ToDo.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private readonly TodoItemRepository _todoItemRepository;

        public ObservableCollection<TodoItemViewModel> Todos { get; set; }

        public MainViewModel(TodoItemRepository todoItemRepository)
        {
            _todoItemRepository.OnTodoAdded += (sender, todo) =>
                Todos.Add(CreateTodoItemViewModel(todo));

            _todoItemRepository.OnTodoUpdated += (sender, todo) =>
                Task.Run(async () => await LoadData());

            _todoItemRepository = todoItemRepository;
            Task.Run(async () => await LoadData());
        }
        public ICommand AddTodo => new Command(async () =>
        {
            var itemView = Resolver.Resolve<ItemView>();
            await Navigation.PushAsync(itemView);
        });

        public string FilterText => ShowAll ? "All" : "Active";

        public ICommand ToggleFilter => new Command(async () =>
        {
            ShowAll = !ShowAll;
            await LoadData();
        });

        public TodoItemViewModel SelectedTodo
        {
            get { return null; }
            set
            {
                Device.BeginInvokeOnMainThread(async () => await NavigateToTodo(value));
                RaisePropertyChanged(nameof(SelectedTodo));
            }
        }

        private async Task LoadData()
        {
            var todos = await _todoItemRepository.GetTodos();

            if (!ShowAll)
            {
                todos = todos.Where(x => x.IsCompleted == false).ToList();
            }

            var itemViewModels = todos.Select(t => CreateTodoItemViewModel(t));
            Todos = new ObservableCollection<TodoItemViewModel>(itemViewModels);
        }

        private TodoItemViewModel CreateTodoItemViewModel(TodoItem todo)
        {
            var todoItemViewModel = new TodoItemViewModel(todo);
            todoItemViewModel.TodoStatusChanged += TodoStatusChanged;
            return todoItemViewModel;
        }

        private async Task NavigateToTodo(TodoItemViewModel todo)
        {
            if (todo == null)
            {
                return;
            }
            var itemView = Resolver.Resolve<ItemView>();
            var itemViewModel = itemView.BindingContext as ItemViewModel;

            itemViewModel.Todo = todo.Todo;
            await Navigation.PushAsync(itemView);
        }

        public bool ShowAll { get; set; }

        private void TodoStatusChanged(object sender, EventArgs e)
        {
            if (sender is TodoItemViewModel todo)
            {
                if (!ShowAll && todo.Todo.IsCompleted)
                {
                    Todos.Remove(todo);
                }

                Task.Run(async () => await _todoItemRepository.UpdateTodo(todo.Todo));
            }
        }
    }
}
