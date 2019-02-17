using JobsWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobsWebSite.DAL;
namespace JobsWebSite.Controllers
{
    
    public class AccountController : Controller
    {
        public static int userid=0;
        public static string usertype = null;
        //
        // GET: /Account/
       
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //////////login/////////////
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult Login(UserProfile user)
        {
            DataAccessLayer dal = new DataAccessLayer();
            UserProfile userprofile= dal.LoginUser(user);
            if (userprofile != null)
            {
                Session["username"] = userprofile.FirstName;
                Session["userid"] =  userprofile.Id;

                Session["usertype"] = usertype=userprofile.UserType;
              userid = userprofile.Id;
                return RedirectToAction("Index", new { controller = "Home", action = "Index"});
                //return View("Index", user);
            }
            else { return RedirectToAction("Index", new { controller = "Home", action = "Index", id = UrlParameter.Optional }); }
        }

    /////////////registration/////////
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register()
        {
            DAL_Roles dal_roles= new DAL_Roles();
            
            ViewBag.UserType = new SelectList(dal_roles.AllRoles());

            return View();
        }
        [HttpPost]
        public ActionResult Register(UserProfile UP)
        {
            DataAccessLayer dal = new DataAccessLayer();
          int rows=  dal.AddUser3(UP);
          if (rows != 0)
          {
              return RedirectToAction("Login", new { controller = "Account", action = "Login", id = UrlParameter.Optional });
          }
          else
          {
              DAL_Roles dal_roles = new DAL_Roles();

              ViewBag.UserType = new SelectList(dal_roles.AllRoles());
              return View(UP);
          }
        }
        //profile////////////////////////
        
        [HttpGet]
        public ActionResult Profile()
        {
            return View();
        }
        /////logout////////////////
        
        public ActionResult Logout()
        {
            Session.Remove("username");
            userid = 0;
            if(userid!=0)
            {
            return RedirectToAction("Index", new { controller = "Home", action = "Index" });
            }
            else { return RedirectToAction("Login", new { controller = "Account", action = "Login" }); }
            }
        
        [HttpGet]
        public ActionResult GetJobsByUser()
        {
            DAL_ApplyForJob dal = new DAL_ApplyForJob();
            List<Jobs> jobs = dal.JobsOfUser(userid);
            if (userid != 0 && usertype == "Applier")
            {
                return View(jobs);
            }
            else { return RedirectToAction("Login", new { controller = "Account", action = "Login" }); }
        }
        
        [HttpGet]
        public ActionResult GetJobsByPublisher()
        {
            DAL_ApplyForJob dal_job = new  DAL_ApplyForJob();
            List<JobsViewModel> pub_jobs = dal_job.GetJobsByPublisher(userid);
            if (userid != 0 && usertype=="Publisher")
            {
                return View(pub_jobs);
            }
            else { return RedirectToAction("Login", new { controller = "Account", action = "Login" }); }
        }
       
    }
}
