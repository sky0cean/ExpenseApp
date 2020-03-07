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

        string budgetfilename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "budget.txt");
        public BudgetEntryPage()
        {
            InitializeComponent();

            if (File.Exists(budgetfilename))
            {
                BudgetEditor.Text = File.ReadAllText(budgetfilename);
            }
        }

        ////Go to Expense Entry page once budget is saved.
        async private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            File.WriteAllText(budgetfilename, BudgetEditor.Text);

            await Navigation.PushAsync(new ExpenseEntryPage(), true);
        }

        //Make budget blank when use delete it
        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            if (File.Exists(budgetfilename))
            {
                File.Delete(budgetfilename);
            }
            BudgetEditor.Text = string.Empty;
        }
    }
}