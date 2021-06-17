using ProjectMVC.Repository;
using ProjectMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMVC.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<ListOrderViewModel> GetListOrder(int index, int size)
        {
            var orders = await _orderRepository.GetOrderWithPaging(index, size);
            int total_result = _orderRepository.GetTotalOrder();
            var result = new ListOrderViewModel
            {
                ListOrder = orders,
                TotalRecord = total_result
            };
            return result;
        }
    }
}
