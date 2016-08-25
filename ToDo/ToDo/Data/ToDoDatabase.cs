using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace ToDo.Data
{
    public class ToDoDatabase
    {
        private SQLiteConnection database;
        static object locker = new object();

        public ToDoDatabase()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<ToDoItem>();
        }

        public int SaveToDo(ToDoItem toDoItem)
        {
            lock (locker)
            {
                if(toDoItem.ID != 0)
                {
                    database.Update(database);
                    return toDoItem.ID;
                }
                else
                {
                    return database.Insert(toDoItem);
                }
            }
        }

        public IEnumerable<ToDoItem> GetToDos()
        {
            lock (locker)
            {
                return (from c in database.Table<ToDoItem>() select c).ToList();
            }
        }

        public ToDoItem GetToDo(int id)
        {
            lock (locker)
            {
                return database.Table<ToDoItem>().Where(c => c.ID == id).FirstOrDefault();
            }
        }
    }
}
