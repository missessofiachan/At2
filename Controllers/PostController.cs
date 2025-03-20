#region

using System.Text.Json;
using At2.Data;
using At2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

#endregion

namespace At2.Controllers;

public class PostController(ApplicationDbContext context) : Controller
{
    private readonly string _jsonFilePath =
        Path.Combine(Directory.GetCurrentDirectory(), "data", "universities_and_qualifications.json");

    // GET: Applicants/Create
    public async Task<IActionResult> Create()
    {
        var model = new Applicant();
        // Read the JSON file for the lists
        var jsonData = await ReadJsonData();
        ViewBag.Universities = jsonData.Universities;
        ViewBag.Qualifications = jsonData.Qualifications;
        return View(model);
    }

    // POST: Applicants/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name,DOB,Qualification,GPA,University")] Applicant applicant)
    {
        if (!ModelState.IsValid)
        {
            var jsonData = await ReadJsonData();
            ViewBag.Universities = jsonData.Universities;
            ViewBag.Qualifications = jsonData.Qualifications;
            return View(applicant);
        }

        if (applicant.GPA < 3.0m)
        {
            ModelState.AddModelError("GPA", "GPA must be 3.0 or higher!");
            var jsonData = await ReadJsonData();
            ViewBag.Universities = jsonData.Universities;
            ViewBag.Qualifications = jsonData.Qualifications;
            return View(applicant);
        }

        context.Add(applicant);
        await context.SaveChangesAsync();
        return RedirectToAction("Index", "home");
    }

    // GET: Applicants/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var applicant = await context.Applicants.FindAsync(id);
        if (applicant == null)
            return NotFound();

        var jsonData = await ReadJsonData();
        ViewBag.Universities = jsonData.Universities;
        ViewBag.Qualifications = jsonData.Qualifications;

        return View(applicant);
    }

    // POST: Applicants/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id,
        [Bind("ApplicantId,Name,DOB,Qualification,GPA,University")]
        Applicant applicant)
    {
        if (id != applicant.ApplicantId)
            return NotFound();

        if (!ModelState.IsValid)
        {
            var jsonData = await ReadJsonData();
            ViewBag.Universities = jsonData.Universities;
            ViewBag.Qualifications = jsonData.Qualifications;
            return View(applicant);
        }

        if (applicant.GPA < 3.0m)
        {
            ModelState.AddModelError("GPA", "GPA must be 3.0 or higher!");
            var jsonData = await ReadJsonData();
            ViewBag.Universities = jsonData.Universities;
            ViewBag.Qualifications = jsonData.Qualifications;
            return View(applicant);
        }

        try
        {
            context.Update(applicant);
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ApplicantExists(applicant.ApplicantId))
                return NotFound();
            throw;
        }

        return RedirectToAction("Index", "home");
    }

    // GET: Applicants/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var applicant = await context.Applicants
            .FirstOrDefaultAsync(m => m.ApplicantId == id);

        if (applicant == null)
            return NotFound();
        return View(applicant);
    }

    // POST: Applicants/Delete/5
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var applicant = await context.Applicants.FindAsync(id);
        if (applicant == null) return RedirectToAction("Index", "home");
        context.Applicants.Remove(applicant);
        await context.SaveChangesAsync();

        return RedirectToAction("Index", "home");
    }

    private bool ApplicantExists(int id)
    {
        return context.Applicants.Any(e => e.ApplicantId == id);
    }

    // Helper method to read and deserialize the JSON file
    private async Task<JsonData> ReadJsonData()
    {
        if (!System.IO.File.Exists(_jsonFilePath))
            // Return empty lists if the file is not found
            return new JsonData
            {
                Universities = [],
                Qualifications = []
            };
        var json = await System.IO.File.ReadAllTextAsync(_jsonFilePath);
        var jsonData = JsonSerializer.Deserialize<JsonData>(json);
        return jsonData;
    }

    // Helper class matching the JSON structure
    private class JsonData
    {
        public List<string> Universities { get; init; } = [];
        public List<string> Qualifications { get; init; } = [];
    }
}