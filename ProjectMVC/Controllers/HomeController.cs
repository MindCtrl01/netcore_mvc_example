using ProjectMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace ProjectMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<Customer> _userManager;
        private readonly SignInManager<Customer> _signinManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(UserManager<Customer> userManager, SignInManager<Customer> signinManager, ILogger<HomeController> logger)
        {
            _userManager = userManager;
            _signinManager = signinManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("login")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (username != null && password != null)
            {
                var user = await _userManager.FindByNameAsync(username);
                if (user != null && await _userManager.CheckPasswordAsync(user, password))
                {
                    try
                    {
                        await _signinManager.SignInAsync(user, isPersistent: false);
                        HttpContext.Session.SetString("username", username);
                        return View("Success");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError("Error when signing in : " + ex.Message);
                        return View("Index");
                    }
                }
                return View("Index");
            }
            else
            {
                ViewBag.error = "Invalid Account";
                return View("Index");
            }
        }

        [Route("logout")]
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _signinManager.SignOutAsync();
                HttpContext.Session.Remove("username");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error when signing out : " + ex.Message);
                return View("Success");
            }
        }
    }
}
