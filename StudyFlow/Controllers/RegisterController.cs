using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StudyFlow.Data;
using StudyFlow.Models;

namespace StudyFlow.Controllers
{
    public class RegisterController : Controller
    {
        //inyeccion de base de datos 
        private readonly AppDbContext _context;
        public RegisterController (AppDbContext context)
        {
            _context = context;
        }
        //get mostrar todo 
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        //post giardar usuarios en db y rediriga a login 
        [HttpPost]
        public IActionResult Create(User newUser)
        {
            if(!ModelState.IsValid)
            {
                return View(newUser);
            }
            _context.User.Add(newUser);
            _context.SaveChanges();
            return RedirectToAction("Index","Login");
        }
    }
}