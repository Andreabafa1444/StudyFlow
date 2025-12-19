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
        return NotFound();
    }

    // remove Subject validation
    ModelState.Remove("Subject");

    // calculate current percentage
    var currentTotal = _context.Evaluations
        .Where(e => e.SubjectId == newevaluation.SubjectId)
        .Sum(e => e.Percentage);

    var newTotal = currentTotal + newevaluation.Percentage;

    if (newTotal > 100)
    {
        ModelState.AddModelError(
            "Percentage",
            "Total percentage cannot be more than 100%"
        );

        return View(newevaluation);
    }

    if (!ModelState.IsValid)
    {
        return View(newevaluation);
    }

    _context.Evaluations.Add(newevaluation);
    _context.SaveChanges();

    return RedirectToAction("Details", "Subjects", new { id = newevaluation.SubjectId });
}

       
  }
}