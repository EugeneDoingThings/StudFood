using StudFood.Models;
using StudFood.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace StudFood.Views
{
    public partial class RecipePage : ContentPage
    {
        private RecipeViewModel _viewModel;
        public RecipePage(IEnumerable<ListPageModel> ingr)
        {
            InitializeComponent();
            _viewModel  = new RecipeViewModel(ingr, this);
            this.BindingContext = _viewModel;
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            _viewModel.OpenDetail.Execute(e.Item);
        }
    }
}




