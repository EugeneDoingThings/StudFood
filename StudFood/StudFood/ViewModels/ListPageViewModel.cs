using StudFood.Models;
using StudFood.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace StudFood.ViewModels
{
    class ListPageViewModel
    {
        public ObservableCollection<ListPageModel> Products { get; set; } = new ObservableCollection<ListPageModel>
        {
            new ListPageModel {Name = "Гречка",Pick = false,},
            new ListPageModel {Name = "Рис",Pick = false,},
            new ListPageModel {Name = "Сыр",Pick = false,},
            new ListPageModel {Name = "Молоко",Pick = false,},
            new ListPageModel {Name = "Картофель",Pick = false,},
            new ListPageModel {Name = "Макароны",Pick = false,},
            new ListPageModel {Name = "Курица",Pick = false,},
            new ListPageModel {Name = "Колбаса",Pick = false,},
            new ListPageModel {Name = "Морковь",Pick = false,},
            new ListPageModel {Name = "Мясо",Pick = false,},
            new ListPageModel {Name = "Рыба",Pick = false,},
            new ListPageModel {Name = "Рис",Pick = false,},
            new ListPageModel {Name = "Чечевица",Pick = false,},
            new ListPageModel {Name = "Гречка",Pick = false,},
            new ListPageModel {Name = "Зелень",Pick = false,},
            new ListPageModel {Name = "Перец",Pick = false,},
            new ListPageModel {Name = "Томаты",Pick = false,},
            new ListPageModel {Name = "Фарш",Pick = false,},
            new ListPageModel {Name = "Масло",Pick = false,},
            new ListPageModel {Name = "Крабовые палочки",Pick = false,},
            new ListPageModel {Name = "Яблоки",Pick = false,},
        };
        private Page _page;
        public ICommand NextCommand { get; set; }

        public ListPageViewModel(Page page)
        {
            _page = page;
            NextCommand = new Command(OpenRecipes);
        }

       

        private async void OpenRecipes()
        {

            var m = Products.Where(x => x.Pick);
            await _page.Navigation.PushAsync(new RecipePage(m));
            
        }

        
    }
}
