using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq.Mapping;
using System.ComponentModel.DataAnnotations;

namespace JobsWebSite.Models
{
    [Table(Name="RoleTable")]
    public class Role
    {
       
        [Key]
        [Column(Name="Id")]
        public int Id{get; set;}
        [Column(Name = "RoleName")]
        [Required(ErrorMessage = "Required")]
        [RegularExpression("[A-Za-z]", ErrorMessage = "Enter Only Alphabets")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "enter at least 3 charachters")]
        public  string RoleName { get; set; }
        public ICollection<UserProfile> Users { set; get; }

    }
}