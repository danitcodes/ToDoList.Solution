using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
  public class ToDoListContext : DbContext //extends from Entity Framework's DBContext w/ built-in DBContext fxn'lty
  {
    public virtual DbSet<Category> Categories { get; set; } //Declaring something as virtual tells our application that we reserve the right to override it.
    public DbSet<Item> Items { get; set; }
    public DbSet<CategoryItem> CategoryItem { get; set; } // join table

    public ToDoListContext(DbContextOptions options) : base(options) { } //a constructor that inherits the behavior of its parent class constructor
  }
}
// each DBSet included becomes a table in database