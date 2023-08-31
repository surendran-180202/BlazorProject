using System.ComponentModel.DataAnnotations;

namespace MyWebPage2.Data
{
    public class tblEducationDetails
    {
        public int? USERID { get; set; }
        [Required]
        public string? TITLE { get; set; }
        [Required]
        public string? YEAR { get; set; }
        [Required]
        public string? CLASS { get; set; }
        [Required]
        public string? INSTITUTE { get; set; }
        [Required]
        public string? PERCENTAGE { get; set; }
        [Required]
        public int LIKES { get; set; }
        [Required]
        public string[]? COMMENT { get; set; }
    }
}
