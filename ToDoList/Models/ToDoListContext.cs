using Microsoft.AspNetCore.Identity.EntityFrameworkCore; //for Identity - user account support & auth
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
  public class ToDoListContext : IdentityDbContext<ApplicationUser>
  //extends from Entity Framework's IdentityDBContext to work with user authentication
  //`ApplicationUser` declared as *type* of IdentityDbContext we/re inheriting in class declarion, which tells Identity which class in the app will contain usr accnt info it will be respon. for authenticating
  {
    public virtual DbSet<Category> Categories { get; set; } //Declaring something as virtual tells our application that we reserve the right to override it.
    public DbSet<Item> Items { get; set; }
    public DbSet<CategoryItem> CategoryItem { get; set; } // join table

    public ToDoListContext(DbContextOptions options) : base(options) { } //a constructor that inherits the behavior of its parent class constructor
  }
}
// each DBSet included becomes a table in database