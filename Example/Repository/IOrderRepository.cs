using Example.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Repository
{
    public interface IOrderRepository
    {
        Task<List<ListOrderViewModel>> GetListOrders(out int total, int index = 0, int size = 6);
    }
}
