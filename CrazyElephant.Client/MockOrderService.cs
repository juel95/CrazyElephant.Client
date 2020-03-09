using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CrazyElephant.Client.Services
{
    class MockOrderService : IOrderService
    {
        public void PlaceOrder(List<string> dishes)
        {
            File.WriteAllLines(@"d:\order.txt", dishes.ToArray());
        }
    }
}
