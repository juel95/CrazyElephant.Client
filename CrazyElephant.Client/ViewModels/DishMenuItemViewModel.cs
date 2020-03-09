using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyElephant.Client.Models;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Commands;

namespace CrazyElephant.Client.ViewModels
{
    //第二次注释
    class DishMenuItemViewModel:BindableBase
    {
        /// <summary>
        /// 有一个Model
        /// </summary>
        public Dish Dish { get; set; }

        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set { SetProperty(ref isSelected, value); }
        }
        
    }
}
