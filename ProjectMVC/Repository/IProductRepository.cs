using ProjectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMVC.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProduct();
    }
}
