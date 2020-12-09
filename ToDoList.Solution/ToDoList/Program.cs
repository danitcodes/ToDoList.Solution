using System;  // cnct to ... ?
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
    string response = Console.ReadLine();
    Console.WriteLine(response);

  //   if (response = "Add" ) {
  //     List<Item> result = Item.GetAll();  //returns the static list; would have to create new instances of list if it were an instance
  //     Console.WriteLine("Please enter new list item description: ");
  //     string newListItem = Console.ReadLine();
  //     Console.WriteLine(newListItem);
  //   } else {
  //     return "false";
  //   }
  }
}