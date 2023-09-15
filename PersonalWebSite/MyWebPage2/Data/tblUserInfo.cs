using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace MyWebPage2.Data
{
    public class tblUserInfo
    {
        public int? USERID { get; set; }
        [Required]
        public byte[]? USERIMAGE { get; set; }
        [Required]
        public string? USERBIO { get; set; }
        [Required]
        public string? NAME { get; set; }
        [Required]
        public string? LASTNAME { get; set; }
        [Required]
        public DateTime BIRTHDAY { get; set; }
        [Required]
        public string? GENDER { get; set; }
        [Required]
        public string? EMAIL { get; set; }
        [Required]
        public long? PHONE { get; set; }
        [Required]
        public string? ADDRESS { get; set; }
    }
}
