using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;  //this connects to namespace in Item.cs
using System.Collections.Generic;
using System;

namespace ToDoList.Test
{
  [TestClass]
  public class ItemTests : IDisposable
  {

    public void Dispose()
    {
      Item.ClearAll();
    }

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
    
    [TestMethod]
    public void SetDescription_SetDescription_String()
    {
      //Arrange
      string description = "Walk the dog.";
      Item newItem = new Item(description);

      //Act
      string updatedDescription = "Do the dishes";
      newItem.Description = updatedDescription;
      string result = newItem.Description;

      //Assert
      Assert.AreEqual(updatedDescription, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_ItemList()
    {
      // Arrange
      List<Item> newList = new List<Item> { };

      //Act
      List<Item> result = Item.GetAll();

      //Asset
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsItems_ItemList()
    {
      //Arrange
      string description01 = "Walk the dog";
      string description02 = "Wash the dishes";
      Item newItem1 = new Item(description01);
      Item newItem2 = new Item(description02);
      List<Item> newList = new List<Item> { newItem1, newItem2 };

      //Act
      List<Item> result = Item.GetAll();
      
      //Assert
      CollectionAssert.AreEqual(newList, result);
    }
  }
}