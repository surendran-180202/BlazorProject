using MyWebPage2.Data;
using Syncfusion.Blazor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

public class DataAccessLayer
{
    public static string connectionString = "Data Source=MS-00715;Initial Catalog=Education;Integrated Security=True";
    public List<tblUser> GetAllUser()
    {
        List<tblUser> PersonDetails = new List<tblUser>();
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("Select * from tblUserData", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tblUser data = new tblUser();
                data.USERID = reader.GetInt32(0);
                data.USERNAME = reader.GetString(1);
                data.EMAIL = reader.GetString(2);
                data.PHONE = reader.GetInt64(3);
                data.PASSWORD = reader.GetString(4);
                PersonDetails.Add(data);
            }
        }
        return PersonDetails;
    }
    public void AddUser(tblUser user)
    {
        string strPersonalQuery = "insert into tblUserData(USERNAME,EMAIL,PHONE,PASSWORD)values (@username,@email,@phone,@password)";
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(strPersonalQuery, con);
            cmd.Parameters.AddWithValue("@username", user.USERNAME);
            cmd.Parameters.AddWithValue("@email", user.EMAIL);
            cmd.Parameters.AddWithValue("@phone", user.PHONE);
            cmd.Parameters.AddWithValue("@password", user.PASSWORD);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
    public bool checkUser(tblUser checkdata)
    {
        bool result = false;
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("Select * from tblUserData", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetString(1).Equals(checkdata.USERNAME) && reader.GetString(4).Equals(checkdata.PASSWORD)) result = true;
            }
        }
        return result;
    }



    public  List<tblExperience> GetAllExperience()
    {
        List<tblExperience> ExperienceDetails = new List<tblExperience>();
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("Select * from tblExperience", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tblExperience data = new tblExperience();
                data.USERID = reader.GetInt32(0);
                data.YEAR = reader.GetString(1);
                data.LEARING = reader.GetString(2);
                data.INSTITUTE = reader.GetString(3);
                ExperienceDetails.Add(data);
            }
        }
        return ExperienceDetails;
    }
}
