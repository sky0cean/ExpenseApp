using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ExpenseApp.Data;

namespace ExpenseApp
{
    public partial class App : Application
    {
        static ExpenseDatabase database;

        public static ExpenseDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ExpenseDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Expenses.db3"));
                }
                return database;
            }
        }

        //public static string FolderPath { get; set; }
        public static string budgetFilename { get; set; }

        public App()
        {
            InitializeComponent();
            //FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            budgetFilename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "budget.txt");
            
            MainPage = new NavigationPage(new BudgetEntryPage());

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
            // Handle when your spp resumes
        }
    }
}
