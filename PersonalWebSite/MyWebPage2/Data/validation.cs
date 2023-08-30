using System.Text.RegularExpressions;

namespace MyWebPage2.Data
{
    public class Validation
    {
        public static bool EmailValidation(string inputEmail)
        {
            bool result = false;
            try
            {
                string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}"+@"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +@".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex re = new Regex(strRegex);
                if (re.IsMatch(inputEmail))
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }

    }
}
