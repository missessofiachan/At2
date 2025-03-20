#region

using At2.Data;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace At2.Controllers;

public class HomeController(ApplicationDbContext context) : Controller
{
    private readonly ApplicationDbContext _context = context;

// GET: Home/Index

    public ActionResult Index(string sortOrder)
    {
        ViewData["CurrentSort"] = sortOrder ?? "Default sort";

        var applicants = _context.Applicants.AsQueryable();
        switch (sortOrder)
        {
            case "gpa_desc":
                applicants = applicants.OrderByDescending(a => a.GPA);
                break;
            case "gpa_asc":
                applicants = applicants.OrderBy(a => a.GPA);
                break;
            case "name_desc":
                applicants = applicants.OrderByDescending(a => a.Name);
                break;
            case "name_asc":
                applicants = applicants.OrderBy(a => a.Name);
                break;
            case "qualification_desc":
                applicants = applicants.OrderByDescending(a => a.Qualification);
                break;
            case "qualification_asc":
                applicants = applicants.OrderBy(a => a.Qualification);
                break;
            case "university_desc":
                applicants = applicants.OrderByDescending(a => a.University);
                break;
            case "university_asc":
                applicants = applicants.OrderBy(a => a.University);
                break;
            case "DOB_desc":
                applicants = applicants.OrderByDescending(a => a.DOB);
                break;
            case "DOB_asc":
                applicants = applicants.OrderBy(a => a.DOB);
                break;
        }

        return View(applicants.ToList());
    }
}