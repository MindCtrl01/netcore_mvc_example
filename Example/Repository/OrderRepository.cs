using Example.Database;
using Example.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Repository
{
    public class OrderRepository
    {
        private readonly ProjectDbContext _context;
        public OrderRepository(ProjectDbContext context)
        {
            _context = context;
        }

        //public Task<List<ListOrderViewModel>> GetListOrders(out int total, int index = 0, int size = 6)
        //{
        //    var result = _context.Orders
        //}
    }
}
