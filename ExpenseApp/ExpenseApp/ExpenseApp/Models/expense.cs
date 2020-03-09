using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ExpenseApp.Models
{
    public class Expense
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        //public string Filename { get; set; }
        public string Product { get; set; }
        public string Price { get; set; }
        //public double Amount { get; set; }
        public DateTime Date { get; set; }

        //public DateTime Date
        //{
        //    get => Date.ToLocalTime();
        //    set
        //    {
        //        Date = value;
        //    }
        //}
        public string Icon { get; set; }
        //public double Balance { get; set; }

        //TODO//  Do something here!!!
        //public double GetSubtraction()
        //{
        //    return Balance - Amount;
        //}

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






    }
}
