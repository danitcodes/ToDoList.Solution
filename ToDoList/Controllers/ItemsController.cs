using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;
using System.Linq; //allows for Linq's ToList() method
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering; //ViewBag access for temp data storage from a controller to a view

namespace ToDoList.Controllers
{
  public class ItemsController : Controller
  {
    private readonly ToDoListContext _db; //constructor that declares a private and readonly field of type

    public ItemsController(ToDoListContext db) //sets new _db property b/c of the dependency injection in AddDbContext method in ConfigureSrvcs in Startup.cs
    {
      _db = db;
    }

    public ActionResult Index() //replaces GetAll()
    {
      List<Item> model = _db.Items.Include(items => items.Category).ToList(); // for each Item in the db, include the Category it belongs to & put all Items into list - uses eager loading (not lazy loading)
      return View(model);
    }

    public ActionResult Create() //same as before w/o Entity - the GET request for creating a new task
    {
      ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Item item) // the POST request for creating a new task
    { 
      _db.Items.Add(item);//takes item as an argument, adds it to the Items DbSet // Add() a method run on DBSet property
      _db.SaveChanges(); // saves changes to database object //SaveChanges() is a method run on the DBContext itself
      return RedirectToAction("Index"); //redirects users to Index view afterwards
    }

    public ActionResult Details(int id) //Details() takes id of entry we want to view
    {
      Item thisItem = _db.Items.FirstOrDefault(items => items.ItemId == id);//id passed in as an arg to LINQ method FirstOrDefault() w/ a lambda
      return View(thisItem);
    }

    public ActionResult Edit(int id) //routes to a page w/ edit item form for specific item
    {
      var thisItem = _db.Items.FirstOrDefault(items => items.ItemId == id);
      ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name"); //want items to belong to categories that already exist - do so w/ view's ViewBag property w/ SelectList helper // SelectList provides all categories for a dropdown menu plus setting the select option value to CategoryId & sel. opt display name to Name
      return View(thisItem);
    }

    [HttpPost]
    public ActionResult Edit(Item item) // updates specific item
    {
      _db.Entry(item).State = EntityState.Modified; //pass item - route parameter - into Entry() method; then update its State property to EntityState.Modified so Entity knows entry has been modified
      _db.SaveChanges(); //once entry state has been marked as Modified, ask the db to SaveChanges()
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id) //gets the correct item and returns it to view
    {
      var thisItem = _db.Items.FirstOrDefault(items => items.ItemId == id);
      return View(thisItem);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id) // post is DeleteConfirmed b/c C# doesn't allow for two methods w/ same signature (= method name & parameters)
    {
      var thisItem = _db.Items.FirstOrDefault(items => items.ItemId == id);
      _db.Items.Remove(thisItem); // built-in Remove() method on db.Items
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}