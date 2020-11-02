using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SQLiteApp
{
    class DataAccess
    {

        //Initialize the SQLite database
        public static void InitializeDatabase()
        {
            using (SqliteConnection db =
               new SqliteConnection("Filename=sqliteSample.db"))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS Customers (userID INTEGER PRIMARY KEY, " +
                    "firstName NVARCHAR(20) NOT NULL, " +
                    "lastName NVARCHAR(20) NOT NULL, " +
                    "EMail NVARCHAR(20) NOT NULL)";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }

        //Insert
        public static void AddData(string inputText)
        {
           
            using (SqliteConnection db =
              new SqliteConnection("Filename=sqliteSample.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO MyTable VALUES (NULL, @name);";
                insertCommand.Parameters.AddWithValue("@name", inputText);

                insertCommand.ExecuteReader();

                db.Close();
            }

        }

        //Retrieve data from the SQLite database
        public static List<String> GetData()
        {
            List<String> entries = new List<string>();

          //  string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "sqliteSample.db");
            using (SqliteConnection db =
               new SqliteConnection("Filename=sqliteSample.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT Text_Entry from MyTable", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                }

                db.Close();
            }

            return entries;
        }
    }
}
