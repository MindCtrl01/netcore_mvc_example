using ProjectMVC.Database;
using ProjectMVC.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectMVC.Models;

namespace ProjectMVC.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ProjectDbContext _context;
        public OrderRepository(ProjectDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateOrder(OrderCreateViewModel orderCreate)
        {
            var order = new Order
            {
                CustomerId = orderCreate.CustomerId,
                ProductId = orderCreate.ProductId,
                OrderDate = orderCreate.OrderDate,
                Amount = orderCreate.Amount
            };
            await _context.Orders.AddAsync(order);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<OrderView>> GetOrderWithPaging(int index, int size)
        {
            int skipCount = index * size;
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

        public async Task<List<OrderView>> GetOrderWithSearchAndPaging(int index, int size, string search)
        {
            int skipCount = index * size;
            var result = await _context.Orders
                               .OrderByDescending(o => o.OrderDate)
                               .Where(o => o.Product.Category.Name == search)
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
