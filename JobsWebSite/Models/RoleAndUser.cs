using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
namespace JobsWebSite.Models
{
    [Table(Name="RoleAndUser")]
    public class RoleAndUser
    {
        
        [Column(Name = "IdRole")]
        public int IdRole { get; set; }

        [Column(Name = "IdUser")]

        public int IdUser { get; set; }
        public UserProfile User_Profile { set; get; }
        public Role role { set; get; }
    }
}