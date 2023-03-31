using CSD.Web.Data;
using CSD.Web.Models;
using Microsoft.AspNetCore.Mvc;

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
        List<Category> categories = _db.Categories.ToList();
        return View(categories);
    }

}