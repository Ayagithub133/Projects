using JobsWebSite.DAL;
using JobsWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace JobsWebSite.Controllers
{
     
    public class HomeController : Controller
    {
        DAL_Category dal_category = new DAL_Category(); 
        //
        // GET: /Home/
        [HttpGet]
        public ActionResult Index()
        {
           List<Category> category = dal_category.RetriveAllCategories();
           return View(category);
        }
        
        [HttpGet]
        public ActionResult Apply()
        {
            if (AccountController.userid != 0 && AccountController.usertype == "Applier")
            {
                return View();
            }else { return RedirectToAction("Login", new { controller = "Account", action = "Login" }); }
            
         }
        [HttpPost]
        public ActionResult Apply(ApplierForJob AFJ) 
        {
            
            
            AFJ.ApplyDate = DateTime.Now;
            //AFJ.ApplierId = (int)(TempData["userid"]);
            //AFJ.JobId = Convert.ToInt32(TempData["jobid"]);
            AFJ.JobId = JobsController.jobid;
            AFJ.ApplierId = AccountController.userid;
            
            Apply apply = new Apply();
            apply.ApplyToJob(AFJ);
            ///////////متنسيش تبقى تحسينى الكود وتتاكدى قبل ما يتقدم على الوظيفه هل اتقدم قبل كدا ولا لا
            return RedirectToAction("Index",new{controller="Home",action="Index"});
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(string SearchName)
        {
            DAL_Job j = new DAL_Job();
           List< Jobs> jobs = j.SearchForJobs(SearchName);
            return View(jobs);
        }
       
        [HttpGet]
        public ActionResult Modify(int id)
        {
            DataAccessLayer dal = new DataAccessLayer();
            UserProfile modify = dal.RetriveUser(id);
            if (AccountController.userid != 0)
            {
                return View(modify);
            }
            else { return RedirectToAction("Login", new { controller = "Account", action = "Login" }); }
            
           
            
            
        }
        [HttpPost]
        public ActionResult Modify(UserProfile user)
        {
            DataAccessLayer dal = new DataAccessLayer();
          int state=  dal.EditUser(user);
        
           if (state == 1)
           { ViewBag.Message = "Your Modifies saved succssfully ."; }
           else
           { ViewBag.Message = "Your Current Password is incorrect ."; }
          return View() ;
        }
    [AllowAnonymous]
    [HttpGet]
    public ActionResult ContactUs()
    {
       return View();
    }
    [HttpPost]
    public ActionResult ContactUs(ContactUsModel contact)
    {
        var mail = new MailMessage();
        var LoginInfo = new NetworkCredential("ayaa.mohamed133@gmail.com", "01113510466");
        mail.From = new MailAddress(contact.Email);
        mail.To.Add(new MailAddress("ayaa.mohamed133@gmail.com"));
        mail.Subject = contact.Subject;
        mail.Body = contact.Message;
        var SmtpClient = new SmtpClient("smtp.gmail.com", 587);
        SmtpClient.EnableSsl = true;
        SmtpClient.Credentials = LoginInfo;
        SmtpClient.Send(mail);
        return View();
    }
}
}
