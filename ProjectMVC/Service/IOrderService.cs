using ProjectMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMVC.Service
{
    public interface IOrderService
    {
        Task<ListOrderViewModel> GetListOrder(int index, int size, string search);
        Task<int> CreateOrder(OrderCreateViewModel order);
    }
}
