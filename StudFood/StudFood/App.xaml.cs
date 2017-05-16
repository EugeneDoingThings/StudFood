using StudFood.Database;
using StudFood.Models;
using StudFood.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace StudFood
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();

            var d = Database;
        }
  
        static RecipeDatabase database;
        public static RecipeDatabase Database
        {
            get
            {

                //string databaseName = Recipe.App.DATABASE_NAME;
                //if (await ApplicationData.Current.LocalFolder.TryGetItemAsync(databaseName) == null)
                //{
                //    StorageFile databaseFile =
                //        await Package.Current.InstalledLocation.GetFileAsync($"Recipes.db}");
                //    await databaseFile.CopyAsync(ApplicationData.Current.LocalFolder);
                //}

                if (database == null)
                {
                    var fileHelper = DependencyService.Get<IFileHelper>();
                    database = new RecipeDatabase(fileHelper.GetLocalFilePath("Recipes.db"));
                }
                return database;
            }
        }
        protected override void OnStart()
        {
          
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
