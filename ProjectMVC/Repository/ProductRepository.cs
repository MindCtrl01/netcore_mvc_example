using Microsoft.EntityFrameworkCore;
using ProjectMVC.Database;
using ProjectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMVC.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProjectDbContext _context;
        public ProductRepository(ProjectDbContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetAllProduct()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
