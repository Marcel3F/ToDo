using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDo.Data;
using Xamarin.Forms;

namespace ToDo
{
    public class App : Application
    {
        private static ToDoDatabase database;
        public static ToDoDatabase Database
        {
            get
            {
                if (database == null)
                    database = new ToDoDatabase();
                return database;
            }
        }

        public App()
        {
            // The root page of your application
            MainPage = new NavigationPage(new CreatePage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
