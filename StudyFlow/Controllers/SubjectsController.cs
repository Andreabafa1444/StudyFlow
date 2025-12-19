using Microsoft.AspNetCore.Mvc;
using StudyFlow.Models;
using StudyFlow.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
        //now we are going to create the Details controller
        [HttpGet]
          public IActionResult Details(string id )
        {
            if(string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            var subject = _context.Subjects
                .Include(s=>s.Evaluations)
                .FirstOrDefault(s=>s.Id == id);

            if (subject == null)
            {
                return NotFound();
            }
            double average = 0;
            if(subject.Evaluations.Any())
            {
                average = subject.Evaluations
                    .Sum(e => e.Grade * e.Percentage / 100.0);
            }    
            if (average >= 7.0)
            {
                subject.Status = SubjectStatus.Approved;
            } 
            else if(average >= 6.5)
            {
                subject.Status = SubjectStatus.AtRisk;
            }       
            else
            {
                subject.Status = SubjectStatus.Failed;
            }
            _context.SaveChanges();
            ViewBag.Average = average;
            return View(subject);
        }
        //mostramos todo 
        public IActionResult Index()
        {
            var subjects = _context.Subjects
                .Include (s => s.Evaluations)
                .ToList();
            return View(subjects);
        }
    } 
}