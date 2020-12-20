using System;
using MySql.Data.MySqlClient; //namespace imported by MySqlConnector package
using ToDoList; //to access DBConfig class in Startup.cs that contains connection string

namespace ToDoList.Models
{
  public class DB
  {
    public static MySqlConnection Connection()
    { // new MySql object named 'conn' using connection string in Startup
      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
      return conn;
    } // this class t4ells app how to connect to database
  }
}