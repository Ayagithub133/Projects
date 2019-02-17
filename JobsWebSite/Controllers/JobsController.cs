using JobsWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using JobsWebSite.DAL;
namespace JobsWebSite.Controllers
{
    
    public class JobsController : Controller
    {
        public static int jobid;
        //
        // GET: /Jobs/
        DAL_Job dal_job = new DAL_Job();

        [HttpGet]
        public ActionResult Index()
        {
            List<Jobs> jobs = dal_job.RetriveAllJobs();
            return View(jobs);
        }
        //////////create/////
        [HttpGet]
        public ActionResult Create()
        { 
            DAL_Category dal_category=new DAL_Category();
            ViewBag.CategoryNames = new SelectList(dal_category.NamesOfCategories());
            if (AccountController.userid != 0 && AccountController.usertype == "Publisher")
            {
                return View();
            }
            else { return RedirectToAction("Login", new { controller = "Account", action = "Login" }); }
            
        }
        [HttpPost]
        public ActionResult Create(Jobs jobs,HttpPostedFileBase upload)
        {
            if (upload == null || checkExtension(upload)!=true)
            { return View(); }
          
            else 
                {
                    string path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                    upload.SaveAs(path);
                    jobs.JobImage = upload.FileName;
                    jobs.Publisher = AccountController.userid;
                    dal_job.AddJob(jobs);
                    return View();
                }
               
           
        }
        
        ///////////////edit/////////
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Jobs job = dal_job.RetriveJobById(id);
            if (AccountController.userid != 0 && AccountController.usertype == "Publisher")
            {
                return View(job);
            }
            else { return RedirectToAction("Login", new { controller = "Account", action = "Login" }); }
            
        }
        [HttpPost]
        public ActionResult Edit(Jobs jobs ,HttpPostedFileBase upload)
        {
            if (upload== null||checkExtension(upload)!=true )
            {
                Jobs J=dal_job.RetriveJobById(jobs.Id);
                string path = Path.Combine(Server.MapPath("~/Uploads"), J.JobImage);
                jobs.JobImage = J.JobImage;
                dal_job.EditJob(jobs);
                

            }
            else
            {
                string path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                upload.SaveAs(path);
                jobs.JobImage = upload.FileName;
                dal_job.EditJob(jobs);
               
            }
            return RedirectToAction("Index");
            
        }
        /////////////////////////delete job/////////////////
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Jobs job = dal_job.RetriveJobById(id);
            if (AccountController.userid != 0 && AccountController.usertype == "Publisher")
            {
                return View(job);
            }
            else { return RedirectToAction("Login", new { controller = "Account", action = "Login" }); }
            
        }
        [HttpPost]
        public ActionResult Delete(Jobs job)
        {
            dal_job.DeleteJob(job.Id);
            return RedirectToAction("Index");
        }
        ///////////////////////Details//////////////
        [HttpGet]
        public ActionResult Details(int id)
        {
            Jobs job = dal_job.RetriveJobById(id);
            //TempData["jobid"] = id;
            jobid = id;
            if (AccountController.userid != 0)
            {
                return View(job);
            }
            else { return RedirectToAction("Login", new { controller = "Account", action = "Login" }); }
            
        }
        //////////////////////////functions check Image/////////////////////
        //////////Chech extension///////////
        private bool checkExtension(HttpPostedFileBase upload)
        {
            string[] Extension = { ".png", ".gpj", ".gif" };
            string str=null;
            int i=0;
            while (upload.FileName.Length>=i)
            {
                if (upload.FileName[i] != '.')
                {
                    i++;
                    continue;
                }
                else {
                    str = upload.FileName.Substring(i);
                    if (str == Extension[0] || str == Extension[1] || str == Extension[2])
                    { return true; }
                    else { return false; }
                

                }
            }
            return false;
        }
        /////////////////////function to check size of image///////////
     
 
    }
}
