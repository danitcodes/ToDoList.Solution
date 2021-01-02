using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;
using System.Collections.Generic;
using System.Linq; //allows for Linq's ToList() method

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
      List<Item> model = _db.Items.ToList(); // db an instance of DbContext class - holding a ref to the database // then the arrived data looks for object 'Items' // which then gets turned into a list with ToList() method from System.Linq namespace
      return View(model);
    }

    public ActionResult Create() //same as before w/o Entity - the GET request for creating a new task
    {
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
      return View(thisItem);
    }

    [HttpPost]
    public ActionResult Edit(Item item) // updates specific item
    {
      _db.Entry(item).State = EntityState.Modified; //pass item - route parameter - into Entry() method; then update its State property to EntityState.Modified so Entity knows entry has been modified
      _db.SaveChanges(); //once entry state has been marked as Modified, ask the db to SaveChanges()
      return RedirectToAction("Index");
    }
  }
}