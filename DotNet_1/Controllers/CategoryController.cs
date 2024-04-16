using DotNet_1.Data;
using DotNet_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNet_1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Name == obj.DisplayOrder.ToString())
                {
                    ModelState.AddModelError("name", "name and Oder Diaplay Cannot be Same");
                }
                else
                {
                    _db.Categories.Add(obj);
                    _db.SaveChanges();
                    TempData["success"] = "Category Added Sucessfully..!";
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            /*if(id== null || id == 0)
            {
                return NotFound();
            }*/
            Category? category_id = _db.Categories.Find(id);//Find() is works with primary Key Only
          //Category? Category_id_1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
          //Category? category_id_2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();
                        
            /*if(category_id == null)
            {
                return NotFound();
            }*/
            return View(category_id);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid) 
                {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "category Updated Successfully..!";
                return RedirectToAction("index");
                }

            return View();
        }

        public IActionResult Delete(int id)
        {
            Category? data = _db.Categories.Find(id);
            return View(data);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {

            Category? data = _db.Categories.Find(id);
            _db.Categories.Remove(data);
            _db.SaveChanges();
            TempData["success"] = "category Deleted Successfuly..!";
            return RedirectToAction("index");
        }
    }
}
