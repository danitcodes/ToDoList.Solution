using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using ToDoList.Models;
using System;

namespace ToDoList.Controllers
{
  public class CategoriesController : Controller
  {
      // [HttpGet("/categories")]
      // public ActionResult Index()
      // {
      //   List<Category> allCategories = Category.GetAll();
      //   return View(allCategories);
      // } //displays list of all Categories

      // [HttpGet("/categories/new")]
      // public ActionResult New()
      // {
      //   return View();
      // } //Offers form to create new Category

      // [HttpPost("/categories")]
      // public ActionResult Create(string categoryName)
      // {
      //   Category newCategory = new Category(categoryName);
      //   return RedirectToAction("Index");
      // } //Creates new Categories on server

      // [HttpGet("/categories/{id}")]
      // public ActionResult Show(int id)
      // {
      //   Dictionary<string, object> model = new Dictionary<string, object>();
      //   Category selectedCategory = Category.Find(id);
      //   List<Item> categoryItems = selectedCategory.Items;
      //   model.Add("category", selectedCategory);
      //   model.Add("items", categoryItems);
      //   return View(model); //View() can only accept one argument
      // } //Displays one specific Category's details

      // [HttpPost("/categories/{categoryId}/items")]
      //   public ActionResult Create(int categoryId, string itemDescription)
      //   {
      //     Dictionary<string, object> model = new Dictionary<string, object>();
      //     Category foundCategory = Category.Find(categoryId);
      //     Item newItem = new Item(itemDescription);
      //     newItem.Save();
      //     foundCategory.Add(newItem);
      //     List<Item> categoryItems = foundCategory.Items;
      //     model.Add("items", categoryItems);
      //     model.Add("category", foundCategory);
      //     return View("Show", model);
      //   } //Creates new Item w/in specific Category on server, not new Categories
      }
}