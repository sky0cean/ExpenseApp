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
        private double UpdateRemain(System.Collections.IEnumerable expenses)
        {
            double budget = double.Parse(budgetLabel.Text);

            double balance = 0.0;
            foreach (Expense e in expenses)
            {
                balance += double.Parse(e.Price);
            }

            double budgetRemain = budget - balance;

            CurrentBudgetLabel.Text = budgetRemain.ToString();

            return budgetRemain;
        }

        private void UpdateFace(ImageSource source, double budgetRemain)
        {
            if (budgetRemain >= 0)
            {
                BudgetImage.Source = "happy.png";
            }
            else
            {
                BudgetImage.Source = "sad.png";
            }
        }

        public ExpensesPage()
        {
            InitializeComponent();

            budgetLabel.Text = File.ReadAllText(App.budgetFilename);
            CurrentBudgetLabel.Text = (0.0).ToString();

        }
      
        protected override async void OnAppearing()
        {

            base.OnAppearing();
      
            listView.ItemsSource = await App.Database.GetNotesAsync();

            double budgetRemain = UpdateRemain(listView.ItemsSource);

            UpdateFace(BudgetImage.Source, budgetRemain);


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