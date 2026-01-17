using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StudyFlow.Models;

namespace StudyFlow.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

