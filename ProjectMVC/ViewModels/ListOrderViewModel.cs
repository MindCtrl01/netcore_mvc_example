using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMVC.ViewModels
{
    public class ListOrderViewModel
    {
        public List<OrderView> ListOrder { get; set; }
        
        public int TotalRecord { get; set; }
    }
    public class OrderView
    {
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public int Amount { get; set; }
    }
}
