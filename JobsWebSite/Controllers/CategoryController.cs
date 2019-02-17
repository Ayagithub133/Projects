using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobsWebSite.DAL;
using JobsWebSite.Models;

namespace JobsWebSite.Controllers
   
{
    
    public class CategoryController : Controller
    {
        //
        // GET: /Category/
        DAL_Category dal_Category = new DAL_Category();
        [HttpGet]
        public ActionResult Index()
        {
            
            List<Category> Categories = dal_Category.RetriveAllCategories();
            if (AccountController.userid != 0 && AccountController.usertype == "Admin")
            {
                return View(Categories);
            }
            else { return RedirectToAction("Login", new { controller = "Account", action = "Login" }); }
            }
       
        ///////create//////
        [HttpGet]
        public ActionResult Create()
        {
            if (AccountController.userid != 0 && AccountController.usertype == "Admin")
            {
                return View();
            }
            else { return RedirectToAction("Login", new { controller = "Account", action = "Login" }); }
            
        }

        [HttpPost]
        public ActionResult Create(Category C)
        {
            dal_Category.AddCategory(C);
           return View();
            //return RedirectToAction("Index");
        }
        //////////////Delete///////////
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Category c = dal_Category.RetriveById(id);
            if (AccountController.userid != 0 && AccountController.usertype == "Admin")
            {
                return View(c);
            }
            else { return RedirectToAction("Login", new { controller = "Account", action = "Login" }); }
            
        }

        [HttpPost]
        public ActionResult Delete(Category c)
        {
            dal_Category.DeleteCategory(c.Id);
            
            return RedirectToAction("Index");
        }
        //////////////Edit//////////
        [HttpGet]
        public ActionResult Edit(int id)
        {
             Category c = dal_Category.RetriveById(id);
             if (AccountController.userid != 0 && AccountController.usertype == "Admin")
             {
                 return View(c);
             }
            else { return RedirectToAction("Login", new { controller = "Account", action = "Login" }); }
            
        }

        [HttpPost]
        public ActionResult Edit(Category C)
        {
            dal_Category.EditCategory(C);
            return RedirectToAction("Index");
            
        }
        ////////////////////
        [HttpGet]
        public ActionResult Details(int id)
        {
         Category C=   dal_Category.RetriveById(id);
         if (AccountController.userid != 0 && AccountController.usertype == "Admin")
         {
             return View(C);
         }
            else { return RedirectToAction("Login", new { controller = "Account", action = "Login" }); }
            
        }
    }
}
