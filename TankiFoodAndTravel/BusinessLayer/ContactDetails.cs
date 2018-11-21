using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TankiFoodAndTravel.DataLayer;
using TankiFoodAndTravel.Models;

namespace TankiFoodAndTravel.BusinessLayer
{
    public class ContactDetails
    {
        ContactDetailsData contactDetailsData = new ContactDetailsData();
        public List<ContactUs> GetContactDetails(string companyName)
        {
            return contactDetailsData.GetContactDetailsFromDB(companyName);
        }

        internal string UpdateAndFetchHitCount()
        {
            return contactDetailsData.UpdateAndFetchHitCount();
        }
    }
}