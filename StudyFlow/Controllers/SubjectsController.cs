using Microsoft.AspNetCore.Mvc;
using StudyFlow.Models;
using StudyFlow.Data;
using System.Linq;
namespace StudyFlow.Controllers
{
  public class SubjectsController : Controller
    {
        private readonly AppDbContext _context;
        //constructor to initialize the context dependency injection
        public SubjectsController(AppDbContext context)
        {
            _context = context;
        }
        //gest all subjects from the database and sends them to the view
        public IActionResult Index()
        {
            var subjects = _context.Subjects.ToList();
            return View(subjects);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Subject newsubject)
        {
            if(!ModelState.IsValid)
            {
                return View(newsubject);
            }
            _context.Subjects.Add(newsubject);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    } 
}