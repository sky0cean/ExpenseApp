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
            ["Gas"]      =      "gas.png",
            ["Grocery"]  =  "grocery.png",
            ["Leisure"]  =  "leisure.png",
            ["Rent"]     =     "rent.png",
            ["Utility"]  =  "utility.png",
        };

        public ExpenseEntryPage()
        {
            InitializeComponent();


            foreach (var key in dic.Keys)
            {
                this.categoryPicker.Items.Add(key);
            }


        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var expense = (Expense)BindingContext;
            if (string.IsNullOrWhiteSpace(expense.Filename))
            {
                Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.expenses.txt");
                File.WriteAllText(expense.Filename, expense.Text);
            }
            else
            {
                File.WriteAllText(expense.Filename, expense.Text);
            }

            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var expense = BindingContext as Expense;
            if (expense == null)
                return;

            if (File.Exists(expense.Filename))
            {
                File.Delete(expense.Filename);
            }
            await Navigation.PopAsync();
        }

        void CategoryChanged(object sender, EventArgs e)
        {
            var selectedCategory = dic.ElementAt(this.categoryPicker.SelectedIndex).Value;

            categoryIcon.Source = selectedCategory;
        }


    }
}