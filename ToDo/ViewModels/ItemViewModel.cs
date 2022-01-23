using System;
using ToDo.Repositories;
using ToDo.ViewModels.Helpers;

namespace ToDo.ViewModels
{
    // This viewmodel is for the todos list view
    public class ItemViewModel : ViewModel
    {
        private readonly TodoItemRepository _todoItemRepository;

        public ItemViewModel(TodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }
    }
}
