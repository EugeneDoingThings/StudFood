using StudFood.Views;
using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace StudFood.ViewModels
{
    class MainPageViewModel
    {
        public ICommand NextCommand { get; set; }

        private Page _page;

        public MainPageViewModel(Page page)
        {
            _page = page;
            //NextCommand = new Command(OpenList);
        }


       
    }

}
