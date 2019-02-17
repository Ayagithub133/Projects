using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;

namespace JobsWebSite.Models
{
    [Table(Name="Jobs")]
    public class Jobs
    {
        [Key]
        [Column(Name="Id")]
        public int Id { set; get; }
        [Display(Name="Job Title")]
        [Column(Name="JobTitle")]
        [Required(ErrorMessage = "Required")]
        public string JobTitle { set; get; }
        [Display(Name = "Job Description")]
        [Column(Name="JobDescription")]
        [Required(ErrorMessage = "Required")]
        public string JobDescription { set; get; }
        [Display(Name = "Job Image")]
        [Column(Name="JobImage")]
        [Required(ErrorMessage = "Required")]
      
        public string JobImage { set; get; }
       // [Display(Name = "Job Type")]
        //public string JobType { set; get; }
        [Required(ErrorMessage = "Required")]
        [Column(Name="CategoryId")]
        [Display(Name = "Category Id")]
        public int? CategoryId { set; get; }
        public Category Category { set; get; }
        public int Publisher { set; get; }

        public ApplierForJob applierForJob { set; get; }
    }
}