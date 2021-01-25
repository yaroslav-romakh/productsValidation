using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ProductsValidation.Models;
using ProductsValidation.Services;

namespace ProductsValidation.Controllers
{
    public class UsersController : Controller
    {
        private List<User> users;

        public UsersController(Data data)
        {
            users = data.Users;
        }

        public IActionResult Index()
        {
            return View("Index", users);
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            users.Add(user);
            return RedirectToAction("Index", users);
        }

        [HttpGet]
        [Route("Users/AddUser/{*params}")]
        public IActionResult AddUser(int id, string name, string email, string role)
        {
            ViewBag.parameters = $"{id}, {name}, {email}, {role}";
            return View();
        }
    }
}
