using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Category
  {
    public Category()
    {
      this.Items = new HashSet<Item>(); //a HashSet is an unordered collection of unique elements - helps avoid exceptions in a constructor when no records exist
    }
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Item> Items { get; set; } //Items declared as an instance of ICollection - a generic interface built into .NET framework - required by Entity
  }// `virtual` Items uses lazy loading
}