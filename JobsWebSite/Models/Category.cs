using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq.Mapping;
using System.ComponentModel.DataAnnotations;

namespace JobsWebSite.Models
{
    [Table(Name="dbo.JobsDataBase")]
    public class Category
    {
        [Key]
        [Column(Name="Id",IsPrimaryKey=true)]
        
        public int Id { set; get; }
        [Display(Name="Category Name")]
        [Column(Name="CategoryName")]
        [Required(ErrorMessage = "Required")]
        public string CategoryName { set; get; }
        [Display(Name="Category Description")]
        [Column(Name="CategoryDescription")]
        [Required(ErrorMessage = "Required")]
        public string CategoryDescription { set; get; }
        public ICollection<Jobs> Jobs { get; set; }

    }
}