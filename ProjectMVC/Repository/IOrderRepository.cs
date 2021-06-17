using ProjectMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMVC.Repository
{
    public interface IOrderRepository
    {
        Task<List<OrderView>> GetOrderWithPaging(int index = 0, int size = 6);
        int GetTotalOrder();
    }
}
