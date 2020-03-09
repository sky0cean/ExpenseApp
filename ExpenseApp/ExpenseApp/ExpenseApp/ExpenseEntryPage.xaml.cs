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

        ////Choose category icons
        //void CategoryChanged(object sender, EventArgs e)
        //{
        //    var selectedCategory = dic.ElementAt(this.categoryPicker.SelectedIndex).Value;

        //    categoryIcon.Source = selectedCategory;
        //}


        async void OnExpenseAddedButtonClicked(object sender, EventArgs e)
        {
            //var expense = (Expense)BindingContext;
            //if (string.IsNullOrWhiteSpace(expense.Filename))
            //{
            //    // Save
            //    var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.expenses.txt");
            //    File.WriteAllText(filename, expense.Text);
            //}
            //else
            //{
            //    // Update
            //    File.WriteAllText(expense.Filename, expense.Text);
            //}

            //await Navigation.PopAsync();

            var expense = (Expense)BindingContext;

            expense.Date = DatePick.Date;
            expense.Product = NameEdit.Text;
            expense.Price = editor.Text;
            expense.Icon = dic.ElementAt(this.categoryPicker.SelectedIndex).Value;
            //expense.Icon = categoryPicker.ItemsSource;
            await App.Database.SaveNoteAsync(expense);
            await Navigation.PopAsync();
        }

        async void OnExpenseDeleteButtonClicked(object sender, EventArgs e)
        {
            //var expense = BindingContext as Expense;
            //if (expense == null)
            //    return;

            //if (File.Exists(expense.Filename))
            //{
            //    File.Delete(expense.Filename);
            //}

            //await Navigation.PopAsync();

            var expense = (Expense)BindingContext;
            await App.Database.DeleteNoteAsync(expense);
            await Navigation.PopAsync();
        }

        private void DatePick_DateSelected(object sender, DateChangedEventArgs e)
        {

        }
    }
}