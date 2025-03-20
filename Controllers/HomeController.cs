#region

using At2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

#endregion

namespace At2.Controllers;

public class HomeController(ApplicationDbContext context) : Controller
{
    private readonly ApplicationDbContext _context = context;


    // GET: Home/Index
    public async Task<IActionResult> Index()
    {
        var applicants = await _context.Applicants
            .OrderByDescending(a => a.GPA)
            .ToListAsync();
        return View(applicants);
    }
}