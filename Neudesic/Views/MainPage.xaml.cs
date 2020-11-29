using Neudesic.Models;
using Xamarin.Forms;

namespace Neudesic.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = App.mainViewmodel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            App.mainViewmodel.IsMainPageLoading = true;
            await InitializeDataAsync();
            App.mainViewmodel.IsMainPageLoading = false;
        }

        private async System.Threading.Tasks.Task InitializeDataAsync()
        {
            await App.mainViewmodel.GetCountriesServiceCallAsync();
            if (App.mainViewmodel.CountriesList == null || App.mainViewmodel.CountriesList.Count == 0)
            {
                countriesListView.IsVisible = false;
                errorLbl.IsVisible = true;
            }
        }

        void ListView_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var contact = e.Item as MyArray;
            Navigation.PushAsync(new MyPageDetail(contact.alpha3Code));
        }
    }
}
