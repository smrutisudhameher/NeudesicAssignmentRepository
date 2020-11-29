using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using MonkeyCache.FileStore;
using Neudesic.Models;
using Neudesic.Functionalities;
using System.Reflection;

namespace Neudesic.Services
{
    public class RestService
    {
        HttpClient _client;
        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<List<MyArray>> GetAllCountries()
        {
            List<MyArray> items = new List<MyArray>();
            try
            {
                Uri uri = new Uri(string.Format(Constants.AllCountriesAPI));
                var CATEGORYESCACHEKEY = "CATEGORYS_CACHE_KEY";
                if (!Barrel.Current.IsExpired(key: CATEGORYESCACHEKEY))
                {
                    items = Barrel.Current.Get<List<MyArray>>(key: CATEGORYESCACHEKEY);
                }
                else
                {
                    Barrel.Current.Empty(key: CATEGORYESCACHEKEY);
                    HttpResponseMessage response = await _client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        items = JsonConvert.DeserializeObject<List<MyArray>>(content);
                        foreach (var item in items)
                            CommonFunctions.ArraytoStringValueInsertion(item, true);
                        Barrel.Current.Add(key: CATEGORYESCACHEKEY, data: items, expireIn: TimeSpan.FromDays(1));
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return items;
        }

        public async Task<MyArray> GetCountryDetail(string countryCode)
        {
            MyArray item = new MyArray();
            try
            {
                Uri uri = new Uri(string.Format(Constants.CountryDetailAPI + countryCode));
                _client = new HttpClient();
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    item = JsonConvert.DeserializeObject<MyArray>(content);
                    CommonFunctions.ArraytoStringValueInsertion(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                item = null;
            }
            return item;
        }
    }
}
