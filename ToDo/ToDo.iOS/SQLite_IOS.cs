using System;
using SQLite;
using ToDo.Data;
using System.IO;
using ToDo.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_IOS))]

namespace ToDo.iOS
{
    class SQLite_IOS: ISQLite
    {

        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "TodoSQLite.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            var path = Path.Combine(libraryPath, sqliteFilename);

            // This is where we copy in the prepopulated database
            Console.WriteLine(path);
            if (!File.Exists(path))
            {
                File.Create(path);
            }

            var conn = new SQLite.SQLiteConnection(path);

            // Return the database connection 
            return conn;
        }
    }
}