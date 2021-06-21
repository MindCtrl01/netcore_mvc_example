using ProjectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMVC.ViewModels
{
    public class OrderCreateSelectionViewModel
    {
        public List<Product> Products { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
