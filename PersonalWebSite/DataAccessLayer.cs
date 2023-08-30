using System;
using System.Collections.Generic;
using System.Module

public class DataAccessLayer
{
    public static string connectionString = "Data Source=MS-00715;Initial Catalog=Education;Integrated Security=True";
    public List<tblUser> GetAllPerson()
    {

        List<TblPerson> PersonDetails = new List<TblPerson>();

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("Select * from tblPerson", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                TblPerson data = new TblPerson();
                data.PERSONID = reader.GetInt32(0);
                data.FIRSTNAME = reader.GetString(1);
                data.LASTNAME = reader.GetString(2);
                data.GENDER = reader.GetString(3);
                data.DOB = reader.GetDateTime(4).ToString("yyyy/MM/dd");
                PersonDetails.Add(data);
            }
        }
        return PersonDetails;
    }
}
