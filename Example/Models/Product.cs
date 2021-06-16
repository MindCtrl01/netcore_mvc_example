using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { set; get; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
