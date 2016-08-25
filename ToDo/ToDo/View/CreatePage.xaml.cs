using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.ViewModel;
using Xamarin.Forms;

namespace ToDo
{
    public partial class CreatePage : ContentPage
    {
        //public List<ToDoItem> toDoItems;
        private CreatePageViewModel vm;
        private int updateID = 0;

        public CreatePage(int id)
        {
            vm = new CreatePageViewModel();
            BindingContext = vm;
            InitializeComponent();

            ToDoItem toDoItem = App.Database.GetToDo(id);
        }

        public CreatePage()
        {
            vm = new CreatePageViewModel();
            BindingContext = vm;
            InitializeComponent();
        }

        public void OnSave(object o, EventArgs e)
        {
            //toDoItems.Add(new ToDoItem(ToDoEntry.Text, Priority.Text, SetDueDate(Date.Date, Time.Time.Hours, Time.Time.Minutes, Time.Time.Seconds), false));
            vm.AddTask(ToDoEntry.Text, Priority.Text, Date.Date, Time.Time.Hours, Time.Time.Minutes, Time.Time.Seconds, false, updateID);
            Clear();
        }

        private void Clear()
        {
            ToDoEntry.Text = string.Empty;
            Priority.Text = string.Empty;
            Date.Date = DateTime.Now;
            Time.Time = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        }

        //private DateTime SetDueDate(DateTime date, int hours, int minutes, int seconds)
        //{
        //    return new DateTime(date.Year, date.Month, date.Day, hours, minutes, seconds);
        //}

        public void OnCancel(object o, EventArgs e)
        {
            Clear();
        }

        public void OnReview(object o, EventArgs e)
        {
            Clear();
            Navigation.PushAsync(new ListTasksPage());
        }
    }
}
