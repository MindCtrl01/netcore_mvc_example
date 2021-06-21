using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMVC.ViewModels
{
    public class OrderCreateViewModel
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string CustomerId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}
    