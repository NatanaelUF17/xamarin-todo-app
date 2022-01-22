using System;
using System.Threading.Tasks;
using ToDo.Repositories;
using ToDo.ViewModels.Helpers;

namespace ToDo.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private readonly TodoItemRepository _todoItemRepository;

        public MainViewModel(TodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
            Task.Run(async () => await LoadData());
        }

        private async Task LoadData()
        {
            throw new NotImplementedException();
        }
    }
}
