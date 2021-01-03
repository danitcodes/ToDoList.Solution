namespace ToDoList.Models
{
  public class Item
  {
    public int ItemId { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; } //Item class now has CategoryId property b/c Item will be associated w/ a category
    public virtual Category Category { get; set; } //property
  }
}