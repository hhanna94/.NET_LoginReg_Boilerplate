using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
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
            string userEmail = HttpContext.Session.GetString("Email");
            ViewBag.Email = userEmail;
            return View();
        }

        // POST MAPPING
        [HttpPost("users/create")]
        public IActionResult CreateUser(User newUser) {
            if (ModelState.IsValid) {
                HttpContext.Session.SetString("Email", newUser.Email);
                return RedirectToAction("Dashboard");
            }
            return View("Index");
        }

        [HttpPost("users/login")]
        public IActionResult LoginUser(LoginUser user) {
            if (ModelState.IsValid) {
                HttpContext.Session.SetString("Email", user.LoginEmail);
                return RedirectToAction("Dashboard");
            }
            return View("Index");
        }


    }
}
