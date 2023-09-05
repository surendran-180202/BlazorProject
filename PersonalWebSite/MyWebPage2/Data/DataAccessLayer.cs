using MyWebPage2.Data;
using MyWebPage2.Pages;
using Syncfusion.Blazor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Numerics;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class DataAccessLayer
{
    internal static int currentUserID { get; set; }
    internal static string? currentUserName { get; set; }
    public static string connectionString = "Data Source=MS-00715;Initial Catalog=SBPERSONAL;Integrated Security=True";
    public List<tblUser> GetAllUser()
    {
        List<tblUser> PersonDetails = new List<tblUser>();
        using(SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("Select * from tblUserData", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
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
        using(SqlConnection con = new SqlConnection(connectionString))
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
        using(SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("Select * from tblUserData", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                if(reader.GetString(1).Equals(checkdata.USERNAME) && reader.GetString(4).Equals(checkdata.PASSWORD))
                {
                    currentUserID = reader.GetInt32(0);
                    currentUserName =reader.GetString(1);
                    result = true;
                }
            }
        }
        return result;
    }
    public List<tblExperience> GetAllExperience()
    {
        List<tblExperience> ExperienceDetails = new List<tblExperience>();
        using(SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("Select * from tblExperience where USERID =@userid", con);
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@userid";
            parameter.Value = currentUserID;
            cmd.Parameters.Add(parameter);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
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
    public List<tblEducationDetails> GetAllEducation()
    {
        List<tblEducationDetails> ExperienceDetails = new List<tblEducationDetails>();
        using(SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("Select * from tblEducationDetails where USERID =@userid", con);
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@userid";
            parameter.Value = currentUserID;
            cmd.Parameters.Add(parameter);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                tblEducationDetails data = new tblEducationDetails();
                data.USERID = reader.GetInt32(0);
                data.TITLE = reader.GetString(1);
                data.YEAR = reader.GetString(2);
                data.CLASS = reader.GetString(3);
                data.INSTITUTE = reader.GetString(4);
                data.PERCENTAGE = reader.GetString(5); 
                data.LIKES =  reader.GetInt32(6);

                ExperienceDetails.Add(data);
            }
        }
        return ExperienceDetails;
    }
    public static List<tblEducationDetailsComments> GetAllComments(string? Title)
    {
        List<tblEducationDetailsComments> ExperienceDetails = new List<tblEducationDetailsComments>();
        using(SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("Select * from tblEducationDetailsComments where TITLE =@title ", con);
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@title";
            parameter.Value = Title;
            cmd.Parameters.Add(parameter);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                tblEducationDetailsComments data = new tblEducationDetailsComments();
                data.USERID = reader.GetInt32(0);
                data.TITLE = reader.GetString(1);
                data.COMMENTEDUSER = reader.GetString(2);
                data.COMMENT = reader.GetString(3);

                ExperienceDetails.Add(data);
            }
        }
        return ExperienceDetails;
    }
    public void NewComment(string newComment,string Title)
    {
       
        string commendedUser = "UnKnown";
        List<tblEducationDetailsComments> commends = new List<tblEducationDetailsComments>();
        string strNewCommmentQuery = "insert into tblEducationDetailsComments(USERID,TITLE,COMMENTEDUSER,COMMENT)values (@userid,@title,@commenteduser,@comment)";
        using(SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(strNewCommmentQuery, con);
            cmd.Parameters.AddWithValue("@userid", currentUserID);
            cmd.Parameters.AddWithValue("@title", Title);
            cmd.Parameters.AddWithValue("@commenteduser", commendedUser);
            cmd.Parameters.AddWithValue("@comment", newComment);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }

    public void AddLike(string Title,int ctrLikeCount)
    {
        
        using(SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("UPDATE tblEducationDetails SET LIKES=@like  WHERE USERID=@userid AND TITLE=@title", con);
            cmd.Parameters.AddWithValue("@userid", currentUserID);
            cmd.Parameters.AddWithValue("@title", Title);
            cmd.Parameters.AddWithValue("@like", ctrLikeCount);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
    public void AddImage(string Title, int ctrLikeCount)
    {

        string strNewCommmentQuery = "insert into tblUserImage(USERID,USERIMAGE,IMAGENAME)values (@userid,@userimage,@imagename)";
        using(SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(strNewCommmentQuery, con);
            cmd.Parameters.AddWithValue("@userid", currentUserID);
            cmd.Parameters.AddWithValue("@userimage", Title);
            cmd.Parameters.AddWithValue("@imagename", "s");
            
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }




    }

    

}
