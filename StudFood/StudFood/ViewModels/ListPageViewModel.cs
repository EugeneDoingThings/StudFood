using StudFood.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudFood.ViewModels
{
    class ListPageViewModel
    {
        public ObservableCollection<ListPageModel> Tasks { get; set; } = new ObservableCollection<ListPageModel>
        {
            new ListPageModel {Name = "Гречка",Pick = false,},
            new ListPageModel {Name = "Рис",Pick = false,},
            new ListPageModel {Name = "Сыр",Pick = false,},
            new ListPageModel {Name = "Молоко",Pick = false,},
            new ListPageModel {Name = "Картофель",Pick = false,},
            new ListPageModel {Name = "Макароны",Pick = false,},
            new ListPageModel {Name = "Курица",Pick = false,},
            };
    }
}
