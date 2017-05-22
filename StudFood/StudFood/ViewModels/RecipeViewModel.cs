using StudFood.Models;
using StudFood.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace StudFood.ViewModels
{
    class RecipeViewModel
    {

        private Page _page;
        

        public ICommand OpenDetail { get; set; }

        private async void Detail(Recipe recipe)
        {
            await _page.Navigation.PushAsync(new DetailedRecipePage(recipe));
        }


        //SELECTION
        public ObservableCollection<Recipe> Recipes { get; set; } = new ObservableCollection<Recipe>();

        public RecipeViewModel(IEnumerable<ListPageModel> ingr, Page page)
        {
            _page = page;
            OpenDetail = new Command<Recipe>(Detail);
            Task.Factory.StartNew(async () =>
            {
                try
                {
                    await LoadRecipes(ingr);
                }
                catch (Exception e)
                {
                    throw;
                }
            });
        }

        private async Task LoadRecipes(IEnumerable<ListPageModel> ingr)
        {
            var allRecipes = await App.Database.GetItemsNotDoneAsync();
            if (ingr == null)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    foreach (var r in allRecipes)
                    {
                        Recipes.Add(r);
                    }
                });
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    var ingrAllEnum = from oneIngr in ingr
                                      select oneIngr.Name.ToUpper();
                    var ingrAllStr = string.Join(",", ingrAllEnum);
                    foreach (var r in allRecipes)
                    {
                        var ingreds = r.Ingredients.Split(',');
                        bool ok = true;
                        foreach (var i in ingreds)
                        {
                            if (!ingrAllStr.Contains(i.Trim().ToUpper()))
                            {
                                ok = false;
                            }
                        }
                        if (ok)
                        {
                            Recipes.Add(r);
                        }
                    }
                });
            }
        }
    }
}
