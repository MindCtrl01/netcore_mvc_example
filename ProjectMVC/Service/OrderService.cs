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

        public Task<int> CreateOrder(OrderCreateViewModel order)
        {
            return _orderRepository.CreateOrder(order);
        }

        public async Task<ListOrderViewModel> GetListOrder(int index, int size, string search)
        {
            int total_result = _orderRepository.GetTotalOrder();
            if (string.IsNullOrEmpty(search))
            {
                var orders = await _orderRepository.GetOrderWithPaging(index, size);
                var result = new ListOrderViewModel
                {
                    ListOrder = orders,
                    TotalRecord = total_result,
                };
                return result;
            }

            var ord = await _orderRepository.GetOrderWithSearchAndPaging(index, size, search);
            var res= new ListOrderViewModel
            {
                ListOrder = ord,
                TotalRecord = total_result
            };
            return res;
        }
    }
}
