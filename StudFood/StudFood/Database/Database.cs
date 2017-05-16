using StudFood.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudFood.Database
{
        public class RecipeDatabase
        {
            readonly SQLiteAsyncConnection database;

            public RecipeDatabase(string dbPath)
            {
                database = new SQLiteAsyncConnection(dbPath);
                database.CreateTableAsync<Recipe>().Wait();
            }

            public Task<List<Recipe>> GetItemsAsync()
            {
                return database.Table<Recipe>().ToListAsync();
            }

            public Task<List<Recipe>> GetItemsNotDoneAsync()
            {
                return database.QueryAsync<Recipe>("SELECT * FROM [Recipes]");
            }

            public Task<Recipe> GetItemAsync(int id)
            {
                return database.Table<Recipe>().Where(i => i.ID == id).FirstOrDefaultAsync();
            }

            public Task<int> SaveItemAsync(Recipe item)
            {
                if (item.ID != 0)
                {
                    return database.UpdateAsync(item);
                }
                else
                {
                    return database.InsertAsync(item);
                }
            }

            public Task<int> DeleteItemAsync(Recipe item)
            {
                return database.DeleteAsync(item);
            }
        }
}
