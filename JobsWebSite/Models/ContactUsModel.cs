using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace JobsWebSite.Models
{
    public class ContactUsModel
    {
        [Required(ErrorMessage = "Required")]
        [Display(Name="Enter Your Name")]
        public string Name { set; get; }
        [Required(ErrorMessage = "Required")]
        [EmailAddress(ErrorMessage="Not Valid")]
        [Display(Name = "Enter Your Email")]
        public string Email { set; get; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Subject")]
        public string Subject { set; get; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Write Your Message")]
        public string Message { set; get; }
    }
}