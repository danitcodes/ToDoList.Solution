using MySql.Data.MySqlClient;
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

    public ItemTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=epicodus;port=3306;database=to_do_list_test;";
    }

  //   [TestMethod]
  //   public void ItemConstructor_CreatesInstanceOfItem_Item()
  //   {
  //     Item newItem = new Item("test");  //would be in regular method code
  //     Assert.AreEqual(typeof(Item), newItem.GetType());
  //     //^ typeof(Item) = test on instance of Item
  //     //^^ newItem.GetType() = regular method code being tested
  //   }

  //   [TestMethod]
  //   public void GetId_ItemsInstantiateWithAnIdAndGetterReturns_Int()
  //   {
  //     //Arrange
  //     string description = "Walk the dog.";
  //     Item newItem = new Item(description);

  //     //Act
  //     int result = newItem.Id;

  //     //Assert
  //     Assert.AreEqual(1, result);
  //   }

  //   [TestMethod]
  //   public void Find_ReturnsCorrectItem_Item()
  //   {
  //     //Arrange
  //     string description01 = "Walk the dog";
  //     string description02 = "Wash the dishes";
  //     Item newItem1 = new Item(description01);
  //     Item newItem2 = new Item(description02);

  //     //Act
  //     Item result = Item.Find(2);

  //     //Assert
  //     Assert.AreEqual(newItem2, result);
  //   }

  //   [TestMethod]
  //   public void GetDescription_ReturnsDescription_String()
  //   {
  //     //Arrange
  //     string description = "Walk the dog.";//creates instance
  //     Item newItem = new Item(description); // pass new instance through Item to add to list
  //     //Act
  //     string result = newItem.Description; //calls on new item added to list
  //     //Assert
  //     Assert.AreEqual(description, result); //tests that expected result matches description of new item
  //   }
    
  //   [TestMethod]
  //   public void SetDescription_SetDescription_String()
  //   {
  //     //Arrange
  //     string description = "Walk the dog.";
  //     Item newItem = new Item(description);

  //     //Act
  //     string updatedDescription = "Do the dishes";
  //     newItem.Description = updatedDescription;
  //     string result = newItem.Description;

  //     //Assert
  //     Assert.AreEqual(updatedDescription, result);
  //   }

    [TestMethod]
    public void GetAll_ReturnsEmptyListFromDatabase_ItemList()
    {
      // Arrange
      List<Item> newList = new List<Item> { };

      //Act
      List<Item> result = Item.GetAll();

      //Asset
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Item()
    {
      //Arrange, Act
      Item firstItem = new Item("Mow the lawn");
      Item secondItem = new Item("Mow the lawn");

      //Assert
      Assert.AreEqual(firstItem, secondItem);
    }

    [TestMethod]
    public void Save_SavesToDatabase_ItemList()
    {
      //Arrange
      Item testItem = new Item("Mow the lawn");

      //Act
      testItem.Save(); //saves
      List<Item> result = Item.GetAll(); // retrieves for verification of save
      List<Item> testList = new List<Item>{testItem};

      //Assert
      CollectionAssert.AreEqual(testList, result); //testList & result should be the same b/c we overrode the Equals() method
    }

    [TestMethod]
    public void GetAll_ReturnsItems_ItemList()
    {
      //Arrange
      string description01 = "Walk the dog";
      string description02 = "Wash the dishes";
      Item newItem1 = new Item(description01);
      newItem1.Save();
      Item newItem2 = new Item(description02);
      newItem2.Save();
      List<Item> newList = new List<Item> { newItem1, newItem2 };

      //Act
      List<Item> result = Item.GetAll();
      
      //Assert
      CollectionAssert.AreEqual(newList, result);
    }
  }
}