using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TankiFoodAndTravel.DataLayer;
using TankiFoodAndTravel.Models;

namespace TankiFoodAndTravel.BusinessLayer
{
    public class ManageLogic
    {
        private ManageData manageData = new ManageData();
        public IndexViewModel UpdateIndexViewModel(string userId)
        {
            return manageData.UpdateIndexViewModel(userId);
        }
    }
}