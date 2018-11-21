using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TankiFoodAndTravel.Models
{
    public class ContactUs
    {
        public ContactUs()
        {
            int num = 1;
            CountryName = "CountryName" + num;
            City = "City" + num;
            State = "State" + num;
            CompanyName = "CompanyName";
        }
        public ContactUs(string _companyName, int num)
        {
            CountryName = "CountryName_" + _companyName + "_" + num;
            City = "City_" + _companyName + "_" + num;
            State = "State_" + _companyName + "_" + num;
            CompanyName = _companyName;
        }

        public ContactUs(string _companyName,string _city, string _state, string _country)
        {
            CompanyName = _companyName;
            City = _city;
            State = _state;
            CountryName = _country;
        }

        public string CountryName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CompanyName { get; internal set; }
    }
}