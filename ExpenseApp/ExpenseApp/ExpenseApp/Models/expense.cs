using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public DateTime Date { get; set; }
        public string Icon { get; set; }
        
    }
}
