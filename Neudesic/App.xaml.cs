using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MonkeyCache.FileStore;
using Neudesic.Views;
using Neudesic.ViewModels;

namespace Neudesic
{
    public partial class App : Application
    {
        public static PagesViewModel mainViewmodel;
        public App()
        {
            InitializeComponent();

            mainViewmodel = new PagesViewModel();
            Barrel.ApplicationId = Constants.BarrelApplicationId;
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
