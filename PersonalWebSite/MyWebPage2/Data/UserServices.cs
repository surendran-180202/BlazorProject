using MyWebPage2.Data;

namespace MyWebPage2.Data
{
    public class UserServices
    {
        DataAccessLayer dataAccessLayer = new DataAccessLayer();
        public string Create(tblUser objCustomer)
        {
            dataAccessLayer.AddUser(objCustomer);
            return "Added Successfully";
        }
        public List<tblUser> GetAllUser()
        {
            List<tblUser> User = dataAccessLayer.GetAllUser().ToList();
            return User;
        }
        public bool UserCheck(tblUser checkUser )
        {
            bool result = false;
            if (dataAccessLayer.checkUser(checkUser) == true) result = true;
            return result;
        }
        public List<tblExperience> Experience()
        {
            List<tblExperience> result = dataAccessLayer.GetAllExperience().ToList();
            return result;
        }
        public List<tblEducationDetails> Education()
        {
            List<tblEducationDetails> result = dataAccessLayer.GetAllEducation().ToList();
            return result;
        }
    }
}
