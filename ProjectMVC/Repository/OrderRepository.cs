using ProjectMVC.Database;
using ProjectMVC.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMVC.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ProjectDbContext _context;
        public OrderRepository(ProjectDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderView>> GetOrderWithPaging(int index = 0, int size = 6)
        {
            int skipCount = index * size;
            if (skipCount == 0)
            {
                var res = await _context.Orders
                               .OrderByDescending(o => o.OrderDate)
                               .Take(size)
                               .Select(o => new OrderView
                               {
                                   ProductName = o.Product.Name,
                                   CategoryName = o.Product.Category.Name,
                                   CustomerName = o.Customer.Name,
                                   OrderDate = o.OrderDate,
                                   Amount = o.Amount
                               })
                               .ToListAsync();
                return res;
            }
            var result = await _context.Orders
                               .OrderByDescending(o => o.OrderDate)
                               .Skip(skipCount)
                               .Take(size)
                               .Select(o => new OrderView
                               {
                                   ProductName = o.Product.Name,
                                   CategoryName = o.Product.Category.Name,
                                   CustomerName = o.Customer.Name,
                                   OrderDate = o.OrderDate,
                                   Amount = o.Amount
                               })
                               .ToListAsync();
            return result;
        }

        public int GetTotalOrder()
        {
            return _context.Orders.Count();
        }
    }
}
