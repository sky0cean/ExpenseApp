using ExpenseApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpenseApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpensesPage : ContentPage
    {
        public ExpensesPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var expenses = new List<Expense>();
            var files = Directory.EnumerateFiles(App.FolderPath, "*.expenses.txt");
            foreach(var filename in files)
            {
                expenses.Add(new Expense
                {
                    Filename = filename,
                    Text = File.ReadAllText(filename),
                    Date = File.GetCreationTime(filename)
                });
            }
  
        }

        private void OnExpenseAddedClicked(object sender, EventArgs e)
        {

        }

        private void OneListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}