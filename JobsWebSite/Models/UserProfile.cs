using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq.Mapping;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using JobsWebSite.DAL;
namespace JobsWebSite.Models
{
    [Table(Name = "UserProfile")]
    public class UserProfile
    {
        [Key]
        public int Id { set; get; }

        [Required(ErrorMessage = "Required")]
        [RegularExpression("[A-Za-z]",ErrorMessage="Enter Only Alphabets")]
        [StringLength(25, MinimumLength = 3,ErrorMessage="enter at least 3 charachters")]
        [Display(Name = "First Name")]
        public string FirstName { set; get; }

        [Required(ErrorMessage = "Required")]
        [RegularExpression("[A-Za-z]",ErrorMessage="Enter Only Alphabets")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "enter at least 3 charachters")]
        [Display(Name = "Last Name")]
        public string LastName { set; get; }

        [Required(ErrorMessage = "Required")]
        [StringLength(50)]
        [Display(Name = "Enter Email")]
        [DataType(DataType.EmailAddress,ErrorMessage="Not Valid")]
        public string Email { set; get; }

        [Required(ErrorMessage="Required")]
        [Display(Name = "User Type")]
        public string UserType { set; get; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [RegularExpression("[A-Za-z0-9]{6,30}",ErrorMessage="Enter only alphabets and number ,length 6")]
        public string UserPassword { set; get; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Confirm Password")]
        [Compare("UserPassword",ErrorMessage="Please Confirm passwort correctly")]
        [DataType(DataType.Password)]
        [RegularExpression("[A-Za-z0-9]{6,30}")]
        public string ConfirmPassword { set; get; }

        [Required]
        public string UserImage { set; get; }

        public ICollection<Role> Roles { set; get; }
        public string FullName { set; get; }


        [Required(ErrorMessage = "Required")]
        [Compare("UserPassword",ErrorMessage="User Password wrong")]
        [Display(Name = "Enter Current Pass")]
        public string CurrentPass { set; get; }
    }
}