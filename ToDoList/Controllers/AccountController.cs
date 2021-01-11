using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity; //new
using ToDoList.Models;
using ToDoList.ViewModels;
using System.Threading.Tasks; // allows for use of asynchronous tasks to use async & await to register new users

namespace ToDoList.Controllers
{
  public class AccountController : Controller
  {
    private readonly ToDoListContext _db;
    private readonly UserManager<ApplicationUser> _userManager; // helps manage saving & updating account info
    private readonly SignInManager<ApplicationUser> _signInManager; // provides fxnlty for users to log into accounts
    //private preferences for _userManager & _signInManager --> w/ a dependency injection int he AccountController constructor to configure

    public AccountController (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ToDoListContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
    }

    public ActionResult Index()
    {
      return View();
    }

    public IActionResult Register()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Register (RegisterViewModel model) //Task class reps async actions that haven't been completed yet
    //Register() action takes a model of type RegisterViewModel as arg
    {
      var user = new ApplicationUser { UserName = model.Email };
      IdentityResult result = await _userManager.CreateAsync(user, model.Password); //async method, UserManager class has built in method CreateAsync() that will create a user w/ the provided pw based on two args - ApplicationUser & pw that will be encrypted when added to db
      if (result.Succeeded)
      {
        return RedirectToAction("Index");
      }
      else
      {
        return View();
      }
    }
  }
}