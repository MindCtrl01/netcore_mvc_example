using ProjectMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMVC.Repository
{
    public interface IOrderRepository
    {
        Task<int> CreateOrder(OrderCreateViewModel order);
        Task<List<OrderView>> GetOrderWithPaging(int index, int size);
        Task<List<OrderView>> GetOrderWithSearchAndPaging(int index, int size, string search = "");
        int GetTotalOrder();
    }
}
