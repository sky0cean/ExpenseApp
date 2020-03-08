using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseApp.Models
{
    public class Expense
    {
        public string Filename { get; set; }
        public string Text { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string Icon { get; set; }
        public double Balance { get; set; }

        //TODO//  Do something here!!!
        public double GetSubtraction()
        {
            return Balance - Amount;
        }

    }    
}
