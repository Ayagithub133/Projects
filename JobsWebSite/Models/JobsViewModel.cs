using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobsWebSite.Models
{
    public class JobsViewModel
    {
        public string JobTitle { set; get; }
        public string FullName { set; get; }
        //public IEnumerable<ApplierForJob> items { set; get; }
        public string Resala { set; get; }
        public DateTime ApplyDate { set; get; }
        
    }
}