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
    public partial class BudgetEntryPage : ContentPage
    {

        string budgetFilename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "budget.txt");
        public BudgetEntryPage()
        {
            InitializeComponent();

            if (File.Exists(budgetFilename))
            {
                BudgetEditor.Text = File.ReadAllText(budgetFilename);
            }
        }

        ////Go to Expense Entry page once budget is saved.
        async private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            File.WriteAllText(budgetFilename, BudgetEditor.Text);

            await Navigation.PushAsync(new ExpensesPage(), true);
        }

        //Make budget blank when user deletes budget
        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            if (File.Exists(budgetFilename))
            {
                File.Delete(budgetFilename);
            }
            BudgetEditor.Text = string.Empty;
        }
    }
}