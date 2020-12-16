using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Item
  {
    public string Description { get; set; }  //constructor more or less
    public int Id { get; }  //readonly property - don't ever manually edit b/c could make Ids not unique
    private static List<Item> _instances = new List<Item> {}; //static is a variable that refers to entire class of Items 
    public Item(string description) // description is argument of new instance
    {
      Description = description;
      //^ Constructor = user argument, & sets lwrCase 'description's home location - "I live here now"
      _instances.Add(this);
      // `this` refers to object being actively created - Add `this` to overarching _instances variable
      Id = _instances.Count;
      // set unique ID for each new list Item instantiated
      // do so *after* adding Items to the _instances list in order to get an updated Count for Id
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