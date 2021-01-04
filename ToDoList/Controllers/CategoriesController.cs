using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ToDoList.Controllers
{
  public class CategoriesController : Controller
  {
    private readonly ToDoListContext _db; //constructor - declares prvt & readonly field

    public CategoriesController(ToDoListContext db)
    { // sets new _db property b/c of dependency injection in Startup.cs
      _db = db;
    }

    public ActionResult Index() //replaces GetAll()
    {
      return View(_db.Categories.ToList());
    }

    public ActionResult Create() //Entity GET Request for new category
    {
      ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Category category, int CategoryId) //POST request for new category
    {
      _db.Categories.Add(category); //takes category as arg, adds to Category DbSet // Add() - built in method run on DBSet property
      if (CategoryId != 0)
      {
        _db.CategoryItem.Add(new CategoryItem() { CategoryId = category.CategoryId, ItemId = category.CategoryId });
      }
      _db.SaveChanges(); //saves changes to db object - run on DBContext itself
      return RedirectToAction("Index"); 
    }

    public ActionResult Details(int id) //takes id of entry to view
    {
      var thisCategory = _db.Categories
          .Include(category => category.Items)
          .ThenInclude(join => join.Item)
          .FirstOrDefault(category => category.CategoryId == id);
      return View(thisCategory);
    }

    public ActionResult Edit(int id) //routes to page w/ edit category form
    {
      var thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      ViewBag.ItemId = new SelectList(_db.Categories, "CategoryId", "Name");
      return View(thisCategory);
    }

    [HttpPost]
    public ActionResult Edit(Category category, int ItemId) //POST result for updating specific category
    {
      if (ItemId != 0)
      {
        _db.CategoryItem.Add(new CategoryItem() { CategoryId = CategoryId, ItemId = item.ItemId});
      }
      _db.Entry(category).State = EntityState.Modified; // category is route parameter, passed into Entry() method, which updates its State property to EntityState.Modified so Entity knows entry has been modified
      _db.SaveChanges(); // once entry state has been marked as Modified, asks the db to SaveChanges()
      return RedirectToAction("Index");
    }

    // public ActionResult Delete(int id) //GETs correct category & returns it to view
    // {
    //   var thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
    //   return View(thisCategory);
    // }

    // [HttpPost, ActionName("Delete")]
    // public ActionResult DeleteConfirmed(int id) // POST is DeleteConfirmed b/c C# can't duplicate method signatures
    // {
    //   var thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
    //   _db.Categories.Remove(thisCategory); //built in Remove()
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }

    public ActionResult AddItem(int id)
    {
      var thisCategory = _db.Categories.FirstOrDefault(categories => categories.CategoryId = id);
      ViewBag.ItemId = new SelectList(_db.Items, "ItemId", "Name");
      return View(thisCategory);
    }

    [HttpPost]
    public ActionResult AddItem(Category category, int ItemId)
    {
      if (ItemId != 0)
      {
        _db.CategoryItem.Add(new CategoryItem() { ItemId = ItemId, CategoryId = category.CategoryId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}