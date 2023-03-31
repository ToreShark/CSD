using CSD.Web.Data;
using CSD.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CSD.Web.Controllers;

public class CategoriesController : Controller
{
    private readonly CSDContext _db;

    public CategoriesController(CSDContext db)
    {
        _db = db;
    }

    public ActionResult Index()
    {
        List<Category> categories = _db.Category.ToList();
        return View(categories);
    }

    public ActionResult Details(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var category = _db.Category.FirstOrDefault(m => m.Id == id);
        if (category is null)
        {
            return NotFound();
        }

        return View(category);
    }

    public IActionResult Create()
    {
        ViewBag.Categories = new SelectList(_db.Category.Where(x => x.ParentId == 0), "Id", "Name");
        return View();
    }

    [HttpPost]
    public IActionResult Create(Category category)
    {
        if (ModelState.IsValid)
        {
            _db.Add(category);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Categories = new SelectList(_db.Category.Where(x => x.ParentId == 0), "Id", "Name");
        return View(category);
    }

    public ActionResult Edit(int id)
    {
        var category = _db.Category.Find(id);
        if (category == null)
        {
            return NotFound();
        }

        ViewBag.Categories = new SelectList(_db.Category.Where(x => x.ParentId == 0), "Id", "Name");

        return View(category);
    }

    // POST: Categories/Edit/5
    [HttpPost]
    public IActionResult Edit(int id, Category category)
    {
        if (id != category.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _db.Update(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        ViewBag.Categories = new SelectList(_db.Category.Where(x => x.ParentId == 0), "Id", "Name");
        return View(category);
    }
}