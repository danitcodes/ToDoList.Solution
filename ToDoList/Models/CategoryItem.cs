namespace ToDoList.Models
{
  public class CategoryItem
  { // no constructor for this model
    public int CategoryItemId { get; set; } //join table id
    public int ItemId { get; set; }
    public int CategoryId { get; set; }
    public Item Item { get; set; } // included as an object
    public Category Category { get; set; } // included as an object
  }
}