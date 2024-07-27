using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project1.Data;
using Project1.Models;

namespace Project1.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var prod = context.Products.Include(e => e.Category).ToList();
            return View(model: prod);
        }
        public IActionResult Details(int id)
        {
            return View(context.Products.Include(e => e.Category).First(e => e.Id == id));
        }

        public IActionResult AddPhone()
        {
            return View();
        }

        public IActionResult SavePhone(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("AddPhone");
        }

    }
}
