using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LoginReg.Models;
using LoginReg.Data;
using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace LoginReg.Controllers
{
    public class HomeController : Controller
    {
        private DataContext _context;

        // Dependency injection of DB context
        public HomeController(DataContext context) {
            _context = context;
        }

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
                if (_context.Users.Any(user => user.Email == newUser.Email)) {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                _context.Users.Add(newUser);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View("Index");
        }

        [HttpPost("users/login")]
        public IActionResult LoginUser(LoginUser user) {
            if (ModelState.IsValid) {
                var userInDb = _context.Users.FirstOrDefault(u => u.Email == user.LoginEmail);
                if (userInDb == null) {
                    ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
                    return View("Index");
                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(user, userInDb.Password, user.LoginPassword);
                if (result == 0) {
                    ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
                    return View("Index");
                }
                HttpContext.Session.SetInt32("UserID", userInDb.Id);
                return RedirectToAction("Dashboard");
            }
            return View("Index");
        }


    }
}
