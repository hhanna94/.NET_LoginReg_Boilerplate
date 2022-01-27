using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LoginReg.Models;

namespace LoginReg.Controllers
{
    public class HomeController : Controller
    {
        // GET MAPPING
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard() {
            return View();
        }

        // POST MAPPING
        [HttpPost("users/create")]
        public IActionResult CreateUser(User newUser) {
            if (ModelState.IsValid) {
                return RedirectToAction("Dashboard");
            }
            return View("Index");
        }

        [HttpPost("users/login")]
        public IActionResult LoginUser(LoginUser user) {
            if (ModelState.IsValid) {
                return RedirectToAction("Dashboard");
            }
            return View("Index");
        }


    }
}
