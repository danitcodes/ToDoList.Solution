using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ToDoList.Models
{
  public class Item
  {
    public string Description { get; set; }  //constructor more or less
    public int Id { get; }  //readonly property - don't ever manually edit b/c could make Ids not unique
    public Item(string description) // description is argument of new instance
    {
      Description = description;
      //^ Constructor = user argument, & sets lwrCase 'description's home location - "I live here now"
      }
    
    public Item(string description, int id) //overload constructor
    {
      Description = description;
      Id = id;
    }

    public override bool Equals(System.Object otherItem) //must go below props & constructors, but above other file methods; Equals() is built into C#
      {
        if (!(otherItem is Item))
        {
          return false;
        }
        else
        {
          Item newItem = (Item) otherItem;
          bool descriptionEquality = (this.Description == newItem.Description);
          return descriptionEquality;
        }
      }
    
    public static List<Item> GetAll()
    { // boilerplate to demonstrate what's under the hood of a .NET app interacting w/ a database; will be refactored again w/ Entity
      List<Item> allItems = new List<Item>{ }; //makes new list
      MySqlConnection conn = DB.Connection(); //MySqlConnection object
      conn.Open(); //line above & current opens a new db cnxn
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand; //query needs to be stored into a MySqlCommand object w/ createCommand() method on the conn object; using as creates an expression that casts cmd into a MySqlCommand object
      cmd.CommandText = @"SELECT * FROM items;";//above & current constructs our SQL query once our cnxn is open; this line is the SQL command; CommandTest property of MySqlCommand object; sets a property value
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader; // resp. for reading data returned by db in response to the above query command; cast rdr type for use w/ MySQl - rdr is the Data Reader (reps actual reading of db) and `as` casts it to MySqlDataReader object
      while (rdr.Read()) //built in method that returns a boolean while it goes through db one at a time, advancing to next record; while loop ends if false
      { // takes ea. indiv record from db and translates into an Item object
        int itemId = rdr.GetInt32(0);
        string itemDescription = rdr.GetString(1);
        Item newItem = new Item(itemDescription, itemId);
        allItems.Add(newItem);
      }
      conn.Close(); // built-in method; important to close db cnxn when done
      if (conn != null) // conditional if our db cnxn fails to close properly
      {
        conn.Dispose(); // only runs if conn is not null
      }
      return allItems;
    }
    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection(); //create conn obj w/ DB.Connection() method
      conn.Open(); //opens the cnxn
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand; //MySqlCommand object
      cmd.CommandText = @"DELETE FROM items;";
      cmd.ExecuteNonQuery(); //SQL statements that modify data are executed
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static Item Find(int searchId)
    {
      //temp placeholder item
      Item placeholderItem = new Item("placeholder item");
      return placeholderItem;
    }
  }
}