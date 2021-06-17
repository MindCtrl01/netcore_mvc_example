using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMVC.Models
{
    public class Customer : IdentityUser
    {
        [MaxLength(100)]
        public string Name { set; get; }
        [MaxLength(255)]
        public string Address { set; get; }
        public ICollection<Order> Orders { get; set; }
    }
}
