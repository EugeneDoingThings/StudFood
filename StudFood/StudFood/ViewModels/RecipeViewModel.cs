using StudFood.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StudFood.ViewModels
{
    class RecipeViewModel
    {
        //public ObservableCollection<RecipePageModel> Recipes { get; set; } = new ObservableCollection<RecipePageModel>
        //{

        //    new RecipePageModel
        //    {
        //        Name = "Спагетти с овощами",
        //        Image = "http://n1s2.hsmedia.ru/38/f5/2a/38f52a3efa2ac2eff689ce0b717928a5/600x401_0_5a66a87e73f18938b56799047d3441a1@800x534_0x59f91261_9117087051381418286.jpeg",
        //        Products = "Спагетти, Томаты, Базилик",
        //    },
        //    new RecipePageModel
        //    {
        //        Name = "Узбекский Плов",
        //        Image = "https://s2.afisha-eda.ru/Photos/120803113558-120814232354-p-O-plov-uzbekskij.jpg",
        //        Products = "Рис, Мясо, Узбеки",
        //    },
        //    new RecipePageModel
        //    {
        //        Name = "Картофель с грибами",
        //        Image = "http://zhenskoe-mnenie.ru/upload/information_system_14/1/2/8/item_12809/information_items_12809.jpg",
        //        Products = "Картофель, Грибы",
        //    },
        //};

        public ObservableCollection<Recipe> Recipes { get; set; } = new ObservableCollection<Recipe>();

        public RecipeViewModel(IEnumerable<ListPageModel> ingr)
        {
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
