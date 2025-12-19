using Microsoft.AspNetCore.Mvc;
using StudyFlow.Models;
using StudyFlow.Data;
using System.Linq;

namespace StudyFlow.Controllers
{
    public class EvaluationController : Controller
    {
        private readonly AppDbContext _context;
        
        public EvaluationController(AppDbContext context)
        {
            _context = context;
        }

   [HttpGet]
public IActionResult Create(string newSubjectId)
{
    if (string.IsNullOrEmpty(newSubjectId))
    {
        return NotFound();
    }

    var subject = _context.Subjects.Find(newSubjectId);
    if (subject == null)
    {
        return NotFound();
    }

    var newevaluation = new Evaluation 
    { 
        SubjectId = newSubjectId  
    };
    
    return View(newevaluation);
}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Evaluation newevaluation)
        {
            if (string.IsNullOrEmpty(newevaluation.SubjectId))
            {
                ModelState.AddModelError("SubjectId", "Subject ID is required");
                return View(newevaluation);
            }

            // ✅ Remover validación del Subject si existe en ModelState
            ModelState.Remove("Subject");

            if (!ModelState.IsValid)
            {
                return View(newevaluation);
            }

            _context.Evaluations.Add(newevaluation);
            _context.SaveChanges();
            
            return RedirectToAction("Index", "Subjects");
        }
    }
}