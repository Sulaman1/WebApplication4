﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    /*[Authorize(Roles = "Admin")]*/
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //[Authorize(Roles ="Member")]
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult PieOfPie()
        {
            return View();
        }

        public IActionResult PDOI()
        {
            return View();  
        }

        public IActionResult Bar()
        {
            return View();
        }

        public IActionResult Render() { 
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}