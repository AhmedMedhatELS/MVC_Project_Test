using Microsoft.AspNetCore.Mvc;
using Project1.Data;
using Project1.Models;

namespace Project1.Controllers
{
    public class CategoryController : Controller
    {
        public ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var cat = context.Categories.ToList();

            return View(model: cat);
        }

        public IActionResult AddCategory()
        {
            return View();
        }


        public IActionResult SaveAddCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var category = context.Categories.Find(id);
            return View(model: category);
        }

        public IActionResult SaveEdit(Category category)
        {
            context.Categories.Update(category);
            context.SaveChanges();
             return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var cat = context.Categories.Find(id);
            context.Categories.Remove(cat);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
