using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StudyFlow.Data;
using StudyFlow.Models;

namespace StudyFlow.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;
        public LoginController (AppDbContext context)
        {
            _context = context;
        }
        //get para mostrar la view del login 
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        //post para validar el login
        [HttpPost]
        public IActionResult Index(string email, string password)
        {
            var user = _context.User.FirstOrDefault(u => u.Email == email && u.Password == password);
            //comprobacion de si existe o no
            if (user == null)
            {
                ViewBag.Error = "Invalid Credentials";
                return View();
            }
            HttpContext.Session.SetInt32("UserId", user.Id);
            return RedirectToAction("Index", "Subjects");
        }
    }
}