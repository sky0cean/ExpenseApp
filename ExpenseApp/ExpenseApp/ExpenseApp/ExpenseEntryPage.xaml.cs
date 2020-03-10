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



    public partial class ExpenseEntryPage : ContentPage
    {   


        //Selections for Category piker
        Dictionary<string, string> dic = new Dictionary<string, string>()
        {
            ["Clothing"] = "clothing.png",
            ["Gas"] = "gas.png",
            ["Grocery"] = "grocery.png",
            ["Leisure"] = "leisure.png",
            ["Rent"] = "rent.png",
            ["Utility"] = "utility.png",
        };


        public ExpenseEntryPage()
        {
            InitializeComponent();


            foreach (var key in dic.Keys)
            {
                this.categoryPicker.Items.Add(key);
            }

            
        }


        async void OnExpenseAddedButtonClicked(object sender, EventArgs e)
        {

            var expense = (Expense)BindingContext;

            expense.Date = DatePick.Date;
            expense.Product = NameEdit.Text;
            expense.Price = editor.Text;
            expense.Icon = dic.ElementAt(this.categoryPicker.SelectedIndex).Value;
            expense.Balance = double.Parse(editor.Text);
            expense.Amount = double.Parse(File.ReadAllText(App.budgetFilename));
            expense.NewBalance = (expense.Amount - expense.Balance).ToString();

            await App.Database.SaveNoteAsync(expense);
            await Navigation.PopAsync();
        }

        async void OnExpenseDeleteButtonClicked(object sender, EventArgs e)
        {
            var expense = (Expense)BindingContext;
            await App.Database.DeleteNoteAsync(expense);
            await Navigation.PopAsync();
        }


    }
}