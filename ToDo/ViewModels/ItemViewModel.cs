using System;
using System.Windows.Input;
using ToDo.Models;
using ToDo.Repositories;
using ToDo.ViewModels.Helpers;
using ToDo.Views;
using Xamarin.Forms;

namespace ToDo.ViewModels
{
    // This viewmodel is for the todos list view
    public class ItemViewModel : ViewModel
    {
        private TodoItemRepository _todoItemRepository;

        public TodoItem Todo { get; set; }

        public ItemViewModel(TodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
            Todo = new TodoItem() { Due = DateTime.Now.AddDays(1) };
        }

        public ICommand SaveTodo => new Command(async () =>
        {
            var mainView = Resolver.Resolve<MainView>();
            await _todoItemRepository.AddOrUpdate(Todo);
            await Navigation.PopAsync();
            //await Navigation.PushAsync(mainView);
        });
    }
}
