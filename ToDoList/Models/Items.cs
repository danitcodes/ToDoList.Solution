using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Item
  {
    public string Description { get; set; }  //constructor more or less
    private static List<Item> _instances = new List<Item> {}; //static is a variable that refers to entire class of Items 
    public Item(string description) // description is argument of new instance
    {
      Description = description;
      //^ Constructor = user argument, & sets lwrCase 'description's home location - "I live here now"
      _instances.Add(this);
      // `this` refers to object being actively created - Add `this` to overarching _instances variable
    }
    public static List<Item> GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
  }
}