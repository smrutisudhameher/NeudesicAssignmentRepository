using System.Threading.Tasks;
using Xamarin.Forms;

namespace Neudesic.Views
{
    public partial class MyPageDetail : ContentPage
    {
        string countryCode;
        public MyPageDetail(string code)
        {
            InitializeComponent();

            countryCode = code;
            BindingContext = App.mainViewmodel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var loading = new ActivityIndicator
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                IsEnabled = true,
                IsRunning = true
            };
            DetailPageScrollView.Content = loading;
            await InitializeDataAsync();
            loading.IsEnabled = false;
            loading.IsRunning = false;
        }

        private async Task InitializeDataAsync()
        {
            await App.mainViewmodel.GetCountryDetailServiceCallAsync(countryCode);
            if (App.mainViewmodel.CountryDetailObject == null)
            {
                var stack = new StackLayout
                {
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                };
                stack.Children.Add(new Label
                {
                    Text = "sorry, could not retrieve data, please try after sometime",
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    FontSize = 16,

                });
                DetailPageScrollView.Content = stack;
            }
            else
                DetailPageScrollView.Content = detailDataGrid;
        }
    }
}
