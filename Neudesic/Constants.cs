using System;
namespace Neudesic
{
    public class Constants
    {
        /// <summary>
        /// base address as to be used for the communication with the web api
        /// required 
        /// 1. IPaddress
        /// 2. Base Address
        /// </summary>
        public static string IPAddress = "restcountries.eu/rest/v2/";
        public static string BaseAddress = "https://" + IPAddress;

        public static string BarrelApplicationId = "com.companyname.neudesic";

        /// <summary>
        /// various api calls through methods
        /// 1. LoginApi - Login Call
        /// 2. LoginApi - Model post
        /// </summary>
        public static string AllCountriesAPI = BaseAddress + "all";//@hsdyn.com/Hitachi
        public static string CountryDetailAPI = BaseAddress + "alpha/";//value

    }
}
