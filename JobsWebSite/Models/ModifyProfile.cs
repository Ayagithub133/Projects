using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq.Mapping;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
namespace JobsWebSite.Models
{
    public class ModifyProfile
    {
        [Required(ErrorMessage = "Required")]
        [RegularExpression("[A-Za-z]", ErrorMessage = "Enter Only Alphabets")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "enter at least 3 charachters")]
        [Display(Name = "First Name")]
        public string FirstName { set; get; }

        [Required(ErrorMessage = "Required")]
        [RegularExpression("[A-Za-z]", ErrorMessage = "Enter Only Alphabets")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "enter at least 3 charachters")]
        [Display(Name = "Last Name")]
        public string LastName { set; get; }

        [Required(ErrorMessage = "Required")]
        [StringLength(50)]
        [Display(Name = "Enter Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Not Valid")]
        public string Email { set; get; }

        [Required(ErrorMessage = "Required")]
        [Compare("UserPassword", ErrorMessage = "User Password wrong")]
        [Display(Name = "Enter Current Pass")]
        public string CurrentPass { set; get; }


        [Required(ErrorMessage = "Required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [RegularExpression("[A-Za-z0-9]{6,30}", ErrorMessage = "Enter only alphabets and number ,length 6")]
        public string UserPassword { set; get; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Confirm Password")]
        [Compare("UserPassword", ErrorMessage = "Please Confirm passwort correctly")]
        [DataType(DataType.Password)]
        [RegularExpression("[A-Za-z0-9]{6,30}")]
        
        public string ConfirmPassword { set; get; }

    }
}