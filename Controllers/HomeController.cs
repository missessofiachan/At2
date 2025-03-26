#region

using At2.Data;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace At2.Controllers;

public class HomeController(ApplicationDbContext context) : Controller
{
    private readonly ApplicationDbContext _context = context;

    // GET: Home/Index
    public ActionResult Index(string sortOrder, string searchQuery)
    {
        ViewData["CurrentSort"] = sortOrder ?? "Default sort";

        var applicants = _context.Applicants.AsQueryable();

        if (!string.IsNullOrEmpty(searchQuery))
            applicants = applicants.Where(a => a.Name.Contains(searchQuery) || a.University.Contains(searchQuery));

        applicants = sortOrder switch
        {
            "gpa_desc" => applicants.OrderByDescending(a => a.GPA),
            "gpa_asc" => applicants.OrderBy(a => a.GPA),
            "name_desc" => applicants.OrderByDescending(a => a.Name),
            "name_asc" => applicants.OrderBy(a => a.Name),
            "qualification_desc" => applicants.OrderByDescending(a => a.Qualification),
            "qualification_asc" => applicants.OrderBy(a => a.Qualification),
            "university_desc" => applicants.OrderByDescending(a => a.University),
            "university_asc" => applicants.OrderBy(a => a.University),
            "DOB_desc" => applicants.OrderByDescending(a => a.DOB),
            "DOB_asc" => applicants.OrderBy(a => a.DOB),
            _ => applicants
        };

        return View(applicants.ToList());
    }
}