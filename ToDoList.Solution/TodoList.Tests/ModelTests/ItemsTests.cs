using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;  //this connects to namespace in ToDoList.cs

namespace ToDoList.Test
{
  [TestClass]
  public class ItemTests
  {
    [TestMethod]
    public void ItemConstructor_CreatesInstanceOfItem_Item()
    {
      Item newItem = new Item("test");  //would be in regular method code
      Assert.AreEqual(typeof(Item), newItem.GetType());
      //^ typeof(Item) = test on instance of Item
      //^^ newItem.GetType() = regular method code being tested
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      //Arrange
      string description = "Walk the dog.";//creates instance
      Item newItem = new Item(description); // pass new instance through Item to add to list
      //Act
      string result = newItem.Description; //calls on new item added to list
      //Assert
      Assert.AreEqual(description, result); //tests that expected result matches description of new item
    }


  }
}