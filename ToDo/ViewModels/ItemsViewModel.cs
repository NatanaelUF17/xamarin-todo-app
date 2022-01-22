using System;
using ToDo.Repositories;
using ToDo.ViewModels.Helpers;

namespace ToDo.ViewModels
{
    // This viewmodel is for the todos list view
    public class ItemsViewModel : ViewModel
    {
        private readonly TodoItemRepository _todoItemRepository;

        public ItemsViewModel(TodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }
    }
}
