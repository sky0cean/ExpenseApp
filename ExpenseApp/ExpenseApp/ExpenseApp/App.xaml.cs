using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpenseApp
{
    public partial class App : Application
    {
        public static string FolderPath { get; set; }
        public App()
        {
            InitializeComponent();
            FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            //Change the page to display in the app to Navigation Class page
            //  TODO// IF Budget is not blank, we should direct user to ExpenseEntry page? 
            MainPage = new NavigationPage(new ExpenseApp.MainPage());
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
