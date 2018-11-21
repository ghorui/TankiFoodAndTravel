using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using TankiFoodAndTravel.Models;
using TankiFoodAndTravel.Utilities;

namespace TankiFoodAndTravel.DataLayer
{
    public class ContactDetailsData
    {
        AppSettings appSettings = new AppSettings();
        public List<ContactUs> GetContactDetailsFromDB(string CompanyName)
        {
            List<ContactUs> contactUs = new List<ContactUs>();
            DataSet ds = new DataSet();

            using (var conn = new SqlConnection(appSettings.GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("GetContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@compName", CompanyName));
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    sqlDataAdapter.Fill(ds);
                    conn.Close();
                }
                catch (Exception ex)
                {
                    conn.Close();
                    throw;
                }
            }

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    contactUs.Add(new ContactUs(CompanyName, dr["city"].ToString(), dr["state"].ToString(), dr["country"].ToString()));
                }
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    contactUs.Add(new ContactUs(CompanyName, i));
                }


                StringBuilder insertQuery = new StringBuilder();
                string query = "INSERT INTO Contact (CompanyName,city,state,country) values (";

                foreach (var contact in contactUs)
                {
                    var currentrow = query + "'" + contact.CompanyName + "'," + "'" + contact.City + "'," + "'" + contact.State + "'," + "'" + contact.CountryName + "');";
                    insertQuery.AppendLine(currentrow);
                }
                using (var conn = new SqlConnection(appSettings.GetConnectionString()))
                {
                    try
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(insertQuery.ToString(), conn);
                        var count = cmd.ExecuteNonQuery();
                        string result = "Number rows affected : " + count;
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        throw;
                    }
                }
            }
            return contactUs;
        }

        internal string UpdateAndFetchHitCount()
        {
            DataSet ds = new DataSet();
            using (var conn = new SqlConnection(appSettings.GetConnectionString()))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UpdateAndFetchHitCount", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@machineName", Environment.MachineName));
                    cmd.Parameters.Add(new SqlParameter("@userName", Environment.UserName));
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    sqlDataAdapter.Fill(ds);
                    conn.Close();
                }
                catch (Exception ex)
                {
                    conn.Close();
                    throw;
                }
            }
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }

            return "0";
        }
    }
}