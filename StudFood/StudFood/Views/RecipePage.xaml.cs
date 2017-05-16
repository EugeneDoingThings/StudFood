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
        public RecipePage(IEnumerable<ListPageModel> ingr)
        {
            InitializeComponent();
            this.BindingContext = new RecipeViewModel(ingr);
        }
    }
}
