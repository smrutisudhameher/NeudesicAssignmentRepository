using System.Collections.ObjectModel;
using Neudesic.Services;
using Neudesic.Models;

namespace Neudesic.ViewModels
{
    public class PagesViewModel : BaseViewModel
    {
        RestService service;

        private ObservableCollection<MyArray> countriesList;
        public ObservableCollection<MyArray> CountriesList
        {
            get { return countriesList; }
            set
            {
                if(countriesList != value)
                {
                    countriesList = value;
                    OnPropertyChanged("CountriesList");
                }
            }
        }

        private MyArray countryDetailObject;
        public MyArray CountryDetailObject
        {
            get { return countryDetailObject; }
            set
            {
                if (countryDetailObject != value)
                {
                    countryDetailObject = value;
                    OnPropertyChanged("CountryDetailObject");
                }
            }
        }

        private bool isMainPageLoading;
        public bool IsMainPageLoading
        {
            get { return isMainPageLoading; }
            set
            {
                if(isMainPageLoading != value)
                {
                    isMainPageLoading = value;
                    OnPropertyChanged("IsMainPageLoading");
                }
            }
        }
        private bool isDetailPageLoading;
        public bool IsDetailPageLoading
        {
            get { return isDetailPageLoading; }
            set
            {
                if (isDetailPageLoading != value)
                {
                    isDetailPageLoading = value;
                    OnPropertyChanged("IsDetailnPageLoading");
                }
            }
        }

        public PagesViewModel()
        {
            service = new RestService();
        }

        internal async System.Threading.Tasks.Task GetCountriesServiceCallAsync()
        {
            if (CountriesList == null || CountriesList.Count == 0)
            {
                var data = await service.GetAllCountries();
                CountriesList = new ObservableCollection<MyArray>(data);
            }
        }

        internal async System.Threading.Tasks.Task GetCountryDetailServiceCallAsync(string countryCode)
        {
            CountryDetailObject = await service.GetCountryDetail(countryCode);
        }
    }
}
