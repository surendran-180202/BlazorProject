using System;
using System.ComponentModel.DataAnnotations;

namespace MyWebPage2.Data
{
    public class tblUser
    {
        public int? USERID { get; set; }
        [Required]
        public string? USERNAME { get; set; }
        [Required]
        public string? EMAIL { get; set; }
        [Required]
        public long? PHONE { get; set; }
        [Required]
        public string? PASSWORD { get; set; }
    }
}
