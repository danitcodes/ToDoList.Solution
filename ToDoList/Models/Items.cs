using System.Collections.Generic;
using System;

namespace ToDoList.Models
{
  public class Item
  {
    public Item()
    {
      this.Categories = new HashSet<CategoryItem>();
    }
    public int ItemId { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; } = false;
    public DateTime DueDate { get; set; }
    public ICollection<CategoryItem> Categories { get; } //a collection navigation property for Categories - only has a get when same property in Category class has both getter & setter
  }
}