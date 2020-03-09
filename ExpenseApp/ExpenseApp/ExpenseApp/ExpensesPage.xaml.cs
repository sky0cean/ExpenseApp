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

            budgetLabel.Text = File.ReadAllText(App.budgetFilename);
           
        }
      
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //var expenses = new List<Expense>();
            //var files = Directory.EnumerateFiles(App.FolderPath, "*.expenses.txt");
            //double sub = Double.Parse(budgetLabel.Text);




            //foreach (var filename in files)
            //{
            //    expenses.Add(new Expense
            //    {
            //        Filename = filename,
            //        Text = File.ReadAllText(filename),                  
            //        Date = File.GetCreationTime(filename),

            //    });
            //    //TODO// Make below code cool with method ?
            //    //Subtract each expense from budget
            //    //sub = sub - Double.Parse(File.ReadAllText(filename));
            //    //CurrentBudgetLabel.Text = sub.ToString();
            //}

            //listView.ItemsSource = expenses.OrderBy(e => e.Date).ToList();        
            listView.ItemsSource = await App.Database.GetNotesAsync();

        }

        //Go to expense Entry page after clicking + button 
        async void OnExpenseAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExpenseEntryPage
            {
                BindingContext = new Expense()
            });
        }

        //Edit existing expense entries
        async void OneListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ExpenseEntryPage
                {
                    BindingContext = e.SelectedItem as Expense
                });
            }
        }

        async void ResetBudgetButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BudgetEntryPage());
        }
    }
}