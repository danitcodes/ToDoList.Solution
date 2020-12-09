namespace ToDoList.Models
{
  public class Item
  {
    public string Description { get; set; }  //constructor more or less

    public Item(string description) // description is argument of new instance
    {
      Description = description;
      //^ Constructor = user argument, & sets lwrCase 'description's home location - "I live here now"
    }
  }
}