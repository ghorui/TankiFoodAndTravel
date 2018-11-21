using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TankiFoodAndTravel.Models;
using TankiFoodAndTravel.Utilities;

namespace TankiFoodAndTravel.DataLayer
{
    public class ManageData
    {
        private AppSettings appSettings = new AppSettings();
        public IndexViewModel UpdateIndexViewModel(string userId)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(appSettings.GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GetIndexViewModelForUserId", conn);
                    cmd.Parameters.Add(new SqlParameter("@userId", userId));
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    sqlDataAdapter.Fill(ds);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                IndexViewModel model = new IndexViewModel();
                model.FirstName = string.IsNullOrEmpty(dr["FirstName"].ToString()) ? "Not Provided" : dr["FirstName"].ToString();
                model.MiddleName = string.IsNullOrEmpty(dr["MiddleName"].ToString()) ? "Not Provided" : dr["MiddleName"].ToString();
                model.LastName = string.IsNullOrEmpty(dr["LastName"].ToString()) ? "Not Provided" : dr["LastName"].ToString();
                model.FacebookLink = string.IsNullOrEmpty(dr["FacebookLink"].ToString()) ? "Not Provided" : dr["FacebookLink"].ToString();
                model.InstagramLink = string.IsNullOrEmpty(dr["InstagramLink"].ToString()) ? "Not Provided" : dr["InstagramLink"].ToString();
                model.TweeterLink = string.IsNullOrEmpty(dr["TweeterLink"].ToString()) ? "Not Provided" : dr["TweeterLink"].ToString();
                return model;
            }
            else
            {
                IndexViewModel model = new IndexViewModel();
                model.FirstName = "Not Provided";
                model.MiddleName = "Not Provided"; 
                model.LastName = "Not Provided"; 
                model.FacebookLink = "Not Provided"; 
                model.InstagramLink = "Not Provided"; 
                model.TweeterLink = "Not Provided";

                return model;
            }
        }
    }
}