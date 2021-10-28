using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.IO;
using System.Text.RegularExpressions;

namespace Bank
{
    class Database
    {
        public SQLiteConnection myConnection;

        public Database()
        {
            myConnection = new SQLiteConnection("Data Source=database.sqlite3");

            if (!File.Exists("./database.sqlite3"))
            {
                Console.WriteLine("Database File Created");
                SQLiteConnection.CreateFile("database.sqlite3");
            }

        }

        public void OpenConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Open)
            {
                myConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Closed)
            {
                myConnection.Clone();
            }
        }

        public class RegularExpressions
        {
            public static string ReguEx = "^[0-9a-zA-Z]+[.+-_]{0,1}[0-9a-zA-Z]+[@][a-zA-Z]+[.][a-zA-Z]{2-3}([a-zA-Z{2,3}){0,1}";

            public bool ValidateEmail()
            {
                return Regex.IsMatch("Talome@gmail.com", ReguEx);
            }
        }
    }
}
