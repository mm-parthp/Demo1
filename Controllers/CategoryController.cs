using Demo1.Data;
using Demo1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicatonDbContext _db;
        public CategoryController(ApplicatonDbContext db)
        {
                _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCateList = _db.categories.ToList();
            return View(objCateList);
        }

        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category cate) 
        {
            if(ModelState.IsValid)
            {
                _db.categories.Add(cate);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id) 
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            Category cateFromDb = _db.categories.Find(id);
            if(cateFromDb==null)
            {
                return NotFound();
            }
            return View(cateFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category cate)
        {
            if(ModelState.IsValid)
            {
                _db.categories.Update(cate);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id) 
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            Category? cateFromDb = _db.categories.Find(id);
            if(cateFromDb==null)
            {
                return NotFound();
            }
            return View(cateFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteP(int? id)
        {
            Category? cate = _db.categories.Find(id);
            if(cate==null)
            {
                return NotFound();
            }
            _db.categories.Remove(cate);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}
