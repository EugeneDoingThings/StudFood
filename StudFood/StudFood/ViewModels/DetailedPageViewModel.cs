using StudFood.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StudFood.ViewModels
{
    class DetailedPageViewModel
    {
        public Recipe DetailedRecipe { get; set; }

        public DetailedPageViewModel(Recipe recipe, Page page)
        {
            DetailedRecipe = recipe;
        }
    }
}
