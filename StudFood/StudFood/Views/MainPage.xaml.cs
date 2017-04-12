using StudFood.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace StudFood.Views
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel(this);
        }
        private void  Menu_ItemClicked(object sender, EventArgs e)
        {
            switch (((Button)sender).Text)
            {
                case "Рецепты":
                    {
                        Detail = new RecipePage();
                        break;
                    }
                case "Выбрать из продуктов":
                    {
                        Detail = new ListPage(); 
                        break;
                    }
            }
            
        }

    }
}
