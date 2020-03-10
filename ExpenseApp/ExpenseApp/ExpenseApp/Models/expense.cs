using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using SQLite;

namespace ExpenseApp.Models
{
    public class Expense: INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        //public string Filename { get; set; }
        public string Product { get; set; }
        public string Price { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string Icon { get; set; }
        public double Balance { get; set; }
        public string newBalance;
        
        public string NewBalance
        {
            get { return newBalance; }
            set
            {
                if (newBalance != value)
                {
                    newBalance = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NewBalance)));
                }
            }
        }








    }
}
