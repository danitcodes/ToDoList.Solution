using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
  public class ToDoListContext : DbContext //extends from Entity Framework's DBContext w/ built-in DBContext fxn'lty
  {
    public DbSet<Item> Items { get; set; }
    public ToDoListContext(DbContextOptions options) : base(options) { } //a constructor that inherits the behavior of its parent class constructor
  }
}