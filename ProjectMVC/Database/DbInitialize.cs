using ProjectMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMVC.Database
{
    public static class DbInitialize
    {
        public static void SeedUser(UserManager<Customer> userManager, IServiceProvider serviceProvider)
        {
            var _context = serviceProvider.GetRequiredService<ProjectDbContext>();
            _context.Database.EnsureCreated();

            var userId = "";
            if (userManager.FindByNameAsync("admin").GetAwaiter().GetResult() == null)
            {
                Customer user = new Customer
                {
                    UserName = "admin",
                    Email = "abc@xyz.com",
                    Name = "Mr Tran",
                    Address = "Hanoi"
                };
                IdentityResult result = userManager.CreateAsync(user, "qwe123").GetAwaiter().GetResult();
                if (result.Succeeded)
                {
                    userId = user.Id;
                }
            }
            else
            {
                userId = userManager.FindByNameAsync("admin").GetAwaiter().GetResult().Id;
            }

            var cate1 = new Category { Name = "Furniture", Description = "This is furniture" };
            var cate2 = new Category { Name = "Furniture 2", Description = "This is furniture 2" };
            _context.Categories.Add(cate1);
            _context.Categories.Add(cate2);
            _context.SaveChanges();
            var prod1 = new Product
            {
                Name = "Chair",
                Description = "This is a chair",
                Price = 10,
                Quantity = 1000,
                CategoryId = cate1.Id
            };
            var prod2 = new Product
            {
                Name = "Table",
                Description = "This is a table",
                Price = 20,
                Quantity = 1000,
                CategoryId = cate2.Id
            };
            _context.Products.Add(prod1);
            _context.Products.Add(prod2);
            _context.SaveChanges();
            var order1 = new Order
            {
                CustomerId = userId,
                ProductId = prod1.Id,
                Amount = 2,
                OrderDate = DateTime.Now
            };
            var order2 = new Order
            {
                CustomerId = userId,
                ProductId = prod2.Id,
                Amount = 1,
                OrderDate = DateTime.Now
            };
            var order3 = new Order
            {
                CustomerId = userId,
                ProductId = prod1.Id,
                Amount = 2,
                OrderDate = DateTime.Now
            };
            var order4 = new Order
            {
                CustomerId = userId,
                ProductId = prod2.Id,
                Amount = 1,
                OrderDate = DateTime.Now
            };
            var order5 = new Order
            {
                CustomerId = userId,
                ProductId = prod1.Id,
                Amount = 2,
                OrderDate = DateTime.Now
            };
            var order6 = new Order
            {
                CustomerId = userId,
                ProductId = prod2.Id,
                Amount = 1,
                OrderDate = DateTime.Now
            };
            _context.Orders.Add(order1);
            _context.Orders.Add(order2);
            _context.Orders.Add(order3);
            _context.Orders.Add(order4);
            _context.Orders.Add(order5);
            _context.Orders.Add(order6);
            _context.SaveChanges();
        }
    }
}
