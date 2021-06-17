using ProjectMVC.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectMVC.ViewModels;

namespace ProjectMVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger, IOrderService orderService)
        {
            _orderService = orderService;
            _logger = logger;
        }
        // GET: Order/List
        public async Task<IActionResult> List([FromQuery(Name = "pageNo")] int pageNo = 1, [FromQuery(Name = "pageSize")] int pageSize = 3)
        {
            _logger.LogInformation("----Getting data------");
            ListOrderViewModel listOrder = await _orderService.GetListOrder(pageNo - 1, pageSize);
            ViewBag.PageNo = pageNo;
            ViewBag.PageSize = pageSize;
            if (listOrder is null)
            {
                _logger.LogError("----Problem getting data-------");
            }
            return View(listOrder);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
