using ProjectMVC.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectMVC.ViewModels;
using ProjectMVC.Models;
using ProjectMVC.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ProjectMVC.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IProductRepository _productRepository;
        private readonly ILogger<OrderController> _logger;
        private readonly UserManager<Customer> _userManager;
        public OrderController(ILogger<OrderController> logger, IOrderService orderService, IProductRepository productRepository, UserManager<Customer> userManager)
        {
            _orderService = orderService;
            _productRepository = productRepository;
            _logger = logger;
            _userManager = userManager;
        }
        // GET: Order/List
        [Authorize]
        public async Task<IActionResult> List([FromQuery(Name = "pageNo")] int pageNo = 1, [FromQuery(Name = "pageSize")] int pageSize = 3, string search = null)
        {
            _logger.LogInformation("----Getting data------");
            
            ListOrderViewModel listOrder = await _orderService.GetListOrder(pageNo - 1, pageSize, search);
            if (listOrder is null)
            {
                _logger.LogError("----Problem getting data-------");
            }

            ViewBag.PageNo = pageNo;
            ViewBag.PageSize = pageSize;

            return View(listOrder);
        }

        // GET: Order/Create
        [Authorize]
        public async Task<IActionResult> Create()
        {
            _logger.LogInformation("----Getting data------");
            var vm = new OrderCreateSelectionViewModel
            {
                Products = await _productRepository.GetAllProduct(),
                Customers = await _userManager.Users.ToListAsync()
            };
            return View(vm);
        }

        // POST: Order/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm]OrderCreateViewModel orderCreate)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create");
            }
            try
            {
                int result = await _orderService.CreateOrder(orderCreate);
                if (result > 0)
                {
                    return RedirectToAction("List");
                }
                _logger.LogError(@"Cannot create order with ProductId = {0} and CustomerId = {1}", orderCreate.ProductId, orderCreate.CustomerId);
                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error when creating order --- " + ex.Message);
                return RedirectToAction("Create");
            }
        }
    }
}
