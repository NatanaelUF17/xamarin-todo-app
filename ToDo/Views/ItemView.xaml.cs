using System;
using System.Collections.Generic;
using ToDo.ViewModels;
using Xamarin.Forms;

namespace ToDo.Views
{
    public partial class ItemView : ContentPage
    {
        public ItemView(ItemViewModel itemViewModel)
        {
            InitializeComponent();
            itemViewModel.Navigation = Navigation;
            BindingContext = itemViewModel;
        }
    }
}
