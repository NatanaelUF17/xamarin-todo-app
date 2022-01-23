using System;
using System.Collections.Generic;
using ToDo.ViewModels;
using Xamarin.Forms;

namespace ToDo.Views
{
    public partial class MainView : ContentPage
    {
        public MainView(MainViewModel mainViewModel)
        {
            InitializeComponent();
            mainViewModel.Navigation = Navigation;
            BindingContext = mainViewModel;
        }
    }
}
