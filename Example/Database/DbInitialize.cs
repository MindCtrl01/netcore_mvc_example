using Example.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Database
{
    public static class DbInitialize
    {
        public static void SeedUser(UserManager<Customer> userManager)
        {
            if (userManager.FindByNameAsync("admin").GetAwaiter().GetResult() == null)
            {
                Customer user = new Customer
                {
                    UserName = "admin",
                    Email = "abc@xyz.com",
                    Name = "Mr Tran",
                    Address= "Hanoi"
                };
                IdentityResult result = userManager.CreateAsync(user, "qwe123").GetAwaiter().GetResult();
            }
            using (var _context = new ProjectDbContext())
            {
                _context.Database.EnsureCreated();

            }
        }
    }
}
