using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using CrazyElephant.Client.Models;
using CrazyElephant.Client.Services;

namespace CrazyElephant.Client.ViewModels
{
    class MainWindowViewModel:BindableBase
    {
        public DelegateCommand PlaceOrderCommand { get; set; }
        public DelegateCommand SelectMenuItemCommand { get; set; }

        private int count;

        public int Count
        {
            get { return count; }
            set { SetProperty(ref count,value); }
        }
        private Restraunt retraunt;

        public Restraunt Restraunt
        {
            get { return retraunt; }
            set { SetProperty(ref retraunt,value); }
        }
        private List<DishMenuItemViewModel> dishMenu;

        public List<DishMenuItemViewModel> DishMenu
        {
            get { return dishMenu; }
            set { SetProperty(ref dishMenu,value); }
        }
        public MainWindowViewModel()
        {
            loadRestraunt();
            loadDishMenu();
            PlaceOrderCommand = new DelegateCommand(PlaceOrderCommandExcute);
            SelectMenuItemCommand = new DelegateCommand(SelectMenuItemCommandExcute);
        }

        private void SelectMenuItemCommandExcute()
        {
            this.Count = this.DishMenu.Count(m => m.IsSelected == true);
        }

        private void PlaceOrderCommandExcute()
        {
            var selectedDishes = this.DishMenu.Where(m => m.IsSelected == true).Select(m => m.Dish.Name).ToList();
            IOrderService orderService = new MockOrderService();
            orderService.PlaceOrder(selectedDishes);
            System.Windows.MessageBox.Show("订餐成功！");
        }

        private void loadDishMenu()
        {
            XmlDataServices xmlDataServices = new XmlDataServices();
            var dishes = xmlDataServices.GetAllDishes();
            this.DishMenu = new List<DishMenuItemViewModel>();
            dishes.ForEach(m => this.DishMenu.Add(new DishMenuItemViewModel() { Dish = m }));
        }

        private void loadRestraunt()
        {
            this.Restraunt = new Restraunt();
            this.Restraunt.Name = "雄记";
            this.Restraunt.Adress = "福建仙游坑北街";
            this.Restraunt.PhoneNumber = "17704622703";
        }
    }
}
