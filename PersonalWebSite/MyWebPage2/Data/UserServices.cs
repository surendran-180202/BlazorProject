using System.ComponentModel.DataAnnotations;
using MyWebPage2.Data;

namespace MyWebPage2.Data
{
    public class UserServices
    {
        DataAccessLayer dataAccessLayer = new DataAccessLayer();

        public int CurrentUserID()
        {
            return DataAccessLayer.currentUserID;
        }
        public string? CurrentUserName()
        {
            return DataAccessLayer.currentUserName;
        }
        public byte[]? CurrentUserImage()
        {
            return DataAccessLayer.currentUserImage;
        }
        public string Create(tblUser newUser)
        {
            dataAccessLayer.AddUser(newUser);
            return "Added Successfully";
        }
        public List<tblUser> GetAllUser()
        {
            List<tblUser> User = dataAccessLayer.GetAllUser().ToList();
            return User;
        }
        public List<tblUserInfo> GetPersonalInfo()
        {
            List<tblUserInfo> User = dataAccessLayer.GetPersonalInfo().ToList();
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
        public void newComment(string NewComment,string Title)
        {
            dataAccessLayer.NewComment(NewComment, Title);
        }
        public void AddLike (string NewLike, int currentLikeCount)
        {
            dataAccessLayer.AddLike(NewLike, currentLikeCount);
        }
        public void imagedata (string sPath) 
        {
            string a = "C:\\Education\\Trining\\Personal Details\\passport size (1).png";
            byte[] data = null;
            FileInfo fInfo = new FileInfo(a);
            long numBytes = fInfo.Length;
            FileStream fStream = new FileStream(a, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            data = br.ReadBytes((int) numBytes);

            tblUserInfo tbldata = new tblUserInfo();


            tbldata.USERID =1;
            tbldata.USERIMAGE=data;
            tbldata.USERBIO ="My Life My Rule";
            tbldata.NAME ="Surendran";
            tbldata.LASTNAME="B";
            tbldata.BIRTHDAY =Convert.ToDateTime("18/02/2002");
            tbldata.GENDER ="Male";
            tbldata.EMAIL ="surendran1822002@gmail.com";
            tbldata.PHONE =8190970043;
            tbldata.ADDRESS ="24/33,vivegananther Street, kulalar Palayam,Bodinayakanur, Theni -625513";
            dataAccessLayer.AddPersonalInfo(tbldata);
        }
        public void UpdateUserInfo(string imageData)
        {
            string a = imageData;
            byte[] data = null;
            FileInfo fInfo = new FileInfo(a);
            long numBytes = fInfo.Length;
            FileStream fStream = new FileStream(a, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            data = br.ReadBytes((int) numBytes);
            tblUserInfo tbldata = new tblUserInfo();

            tbldata.USERID =1;
            tbldata.USERIMAGE=data;
            tbldata.USERBIO ="My Life My Rule";
            tbldata.NAME ="Surendran";
            tbldata.LASTNAME="B";
            tbldata.BIRTHDAY =Convert.ToDateTime("18/02/2002");
            tbldata.GENDER ="Male";
            tbldata.EMAIL ="surendran1822002@gmail.com";
            tbldata.PHONE =8190970043;
            tbldata.ADDRESS ="24/33,vivegananther Street, kulalar Palayam,Bodinayakanur, Theni -625513";
            dataAccessLayer.UpdatePersonalInfo(tbldata);
        }
        public List<string> motivationQuote()
        {
            string quote = "SUCCESS IS NOT FATAL: FAILURE; IS NOT FATAL IT IS THE COURAGE TO CONTINUE THAT COUNTS";
            List<string> quoteData = new List<string>();
            string[] SplitedData= quote.Split(' ');
            quoteData.AddRange(SplitedData);
            return quoteData;
        }

    }
}
