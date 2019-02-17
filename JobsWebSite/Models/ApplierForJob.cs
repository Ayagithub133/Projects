using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq.Mapping;
using System.ComponentModel.DataAnnotations;
namespace JobsWebSite.Models
{
    [Table(Name="ApplyForJob")]
    public class ApplierForJob
    {
        [Column(Name = "Resala")]
        public string Resala { set; get; }
        [Column(Name = "ApplyDate")]
        public DateTime ApplyDate { get; set; }
        [Column(Name = "JobId")]
        public int JobId { set; get; }
        [Column(Name = "ApplierId")]
        public int ApplierId { set; get; }
        public UserProfile user_profile{set; get;}
        public Jobs Job { set; get; }
        public Jobs jobtitle;
        public string FullName { set; get; }




   
    }
}