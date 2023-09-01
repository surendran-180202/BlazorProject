using MyWebPage2.Data;
using Syncfusion.Blazor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

public class DataAccessLayer
{
    public static string connectionString = "Data Source=MS-00715;Initial Catalog=Education;Integrated Security=True";
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
                if(reader.GetString(1).Equals(checkdata.USERNAME) && reader.GetString(4).Equals(checkdata.PASSWORD)) result = true;
            }
        }
        return result;
    }



    public List<tblExperience> GetAllExperience()
    {
        List<tblExperience> ExperienceDetails = new List<tblExperience>();
        using(SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("Select * from tblExperience", con);
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
        List<tblEducationDetails> ExperienceDetails = new List<tblEducationDetails>()
        {
             new tblEducationDetails(){ USERID = 1, TITLE="school",YEAR ="2022-2023",CLASS="12 th",INSTITUTE="zkm.hr.sec.school",PERCENTAGE="99%",LIKES=22},
             new tblEducationDetails(){ USERID = 1, TITLE="UG",YEAR ="2022-2023",CLASS="12 th",INSTITUTE="zkm.hr.sec.school",PERCENTAGE="99%",LIKES=22},
             new tblEducationDetails(){ USERID = 1, TITLE="PG",YEAR ="2022-2023",CLASS="12 th",INSTITUTE="zkm.hr.sec.school",PERCENTAGE="99%",LIKES=22}
        };




 




        return ExperienceDetails;

    }
    public static List<tblEducationDetailsComments> GetAllComments(string? Title)
    {
        List<tblEducationDetailsComments> ExperienceDetails = new List<tblEducationDetailsComments>()
        {
             new tblEducationDetailsComments(){ USERID = 1, TITLE="school",COMMENTEDUSER="surendran@123",COMMENT="This is cool"},
             new tblEducationDetailsComments(){ USERID = 1, TITLE="UG",COMMENTEDUSER="surendran",COMMENT="fentastic"},
             new tblEducationDetailsComments(){ USERID = 1, TITLE="PG",COMMENTEDUSER="vj",COMMENT="suppcugcucgtcujcucucucucucycuer"},
              new tblEducationDetailsComments(){ USERID = 1, TITLE="PG",COMMENTEDUSER="arun",COMMENT="supper"},
               new tblEducationDetailsComments(){ USERID = 1, TITLE="PG",COMMENTEDUSER="naveen",COMMENT="supper"},
        };
        List<tblEducationDetailsComments> ExperienceDetails1 = new List<tblEducationDetailsComments>();
        foreach(var i in ExperienceDetails)
        {
            if(i.TITLE == Title)
            {
                ExperienceDetails1.Add(i);
            }
        }

        return ExperienceDetails1;
    }
 }
