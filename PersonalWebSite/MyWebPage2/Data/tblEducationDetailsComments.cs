using System.ComponentModel.DataAnnotations;

namespace MyWebPage2.Data
{
    public class tblEducationDetailsComments
    {
        public int USERID { get; set; }
        [Required]
        public string? TITLE { get; set; }
        [Required]
        public string? COMMENTEDUSER { get; set; }
        [Required]
        public string? COMMENT { get; set; }
    }
}




