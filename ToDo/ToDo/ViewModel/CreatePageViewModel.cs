using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.ViewModel
{
    public class CreatePageViewModel
    {
        public void AddTask(string toDo, string priority, DateTime dueDate, int hour, int minute, int second, bool isDeleted, int updateID)
        {
            var newToDo = new ToDoItem
            {
                TaskName = toDo,
                Priority = priority,
                DueDate = SetDueDate(dueDate, hour, minute, second),
                IsDeleted = isDeleted,
                ID = updateID
            };

            App.Database.SaveToDo(newToDo); 
        }

        public DateTime SetDueDate(DateTime date, int hours, int minutes, int seconds)
        {
            return new DateTime(date.Year, date.Month, date.Day, hours, minutes, seconds);
        }
    }
}
