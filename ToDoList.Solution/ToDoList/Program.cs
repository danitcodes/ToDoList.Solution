using System;  // cnct to Read/write Console fxn
using System.Collections.Generic; //cnct to built-in items
using ToDoList.Models;  //cnct to biz logic

//Add()
//View()

public class Program 
{
  public static void Main()
  {
    Console.WriteLine("Welcome to the To Do List.");
    Console.WriteLine("--------------------------");
    Console.WriteLine("Would you like to add an item to your list or view your list? (Add/View)");
    string response = Console.ReadLine().ToLower();
    

    if (response == "add") {
      List<Item> result = Item.GetAll();  //returns the static list; would have to create new instances of list if it were an instance
      Console.WriteLine("Please enter new list item description: ");
      string newListItem = Console.ReadLine();
      Item newItem = new Item(newListItem);
      Program.Main();
    } 
    else if (response == "view")
    {
      Item.GetAll().ForEach(i => Console.WriteLine(i.Description));
      Program.Main();
    }
    else {
      Console.WriteLine("false");
    }
  }
}

