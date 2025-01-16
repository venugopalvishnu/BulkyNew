using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
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
            List<Category> ObjCategoryList = _db.Categories.ToList();
            return View(ObjCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The display order cannot exact match in name.");
            }
            if (obj.Name!=null && obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "The test is not allowd.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Created Sucessfully..!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int? Id)
        {
            if(Id==null || Id == 0)
            {
                return NotFound();
            }
            Category? categoryfromDb = _db.Categories.Find(Id);
            //different methode to retrive data from db
            //Category? categoryfromDb1 = _db.Categories.FirstOrDefault(U => U.Id == Id);
            //Category? categoryfromDb2 = _db.Categories.Where(U=> U.Id==Id).FirstOrDefault();
            if (categoryfromDb == null)
            {
                return NotFound();
            }
            return View(categoryfromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {          
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Updated Sucessfully..!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            Category? categoryfromDb = _db.Categories.Find(Id);
            //different methode to retrive data from db
            //Category? categoryfromDb1 = _db.Categories.FirstOrDefault(U => U.Id == Id);
            //Category? categoryfromDb2 = _db.Categories.Where(U=> U.Id==Id).FirstOrDefault();
            if (categoryfromDb == null)
            {
                return NotFound();
            }
            return View(categoryfromDb);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? Id)
        {
            Category? categoryfromDb = _db.Categories.Find(Id);
            if (categoryfromDb == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(categoryfromDb);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted Sucessfully..!";
            return RedirectToAction("Index");           
        }
    }
}
