using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpenseApp
{
    public partial class App : Application
    {
        private string budgetFilename;

        public static string FolderPath { get; set; }
    
        public App()
        {
            InitializeComponent();
            FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);


            //If User sets budget, goto Expense page, else go to Budget entry page 
            if (File.Exists(budgetFilename))
            {
                MainPage = new NavigationPage(new ExpensesPage());
            }
            else
            {
                MainPage = new NavigationPage(new BudgetEntryPage());
            }
            

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
