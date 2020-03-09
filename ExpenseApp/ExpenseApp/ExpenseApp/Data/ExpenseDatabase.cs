using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using ExpenseApp.Models;


namespace ExpenseApp.Data
{
    public class ExpenseDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public ExpenseDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Expense>().Wait();
        }

        public Task<List<Expense>> GetNotesAsync()
        {
            return _database.Table<Expense>().ToListAsync();
        }

        public Task<Expense> GetNoteAsync(int id)
        {
            return _database.Table<Expense>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(Expense expense)
        {
            if (expense.ID != 0)
            {
                return _database.UpdateAsync(expense);
            }
            else
            {
                return _database.InsertAsync(expense);
            }
        }

        public Task<int> DeleteNoteAsync(Expense expense)
        {
            return _database.DeleteAsync(expense);
        }
    }
}
