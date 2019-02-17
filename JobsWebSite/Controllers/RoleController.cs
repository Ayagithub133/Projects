using JobsWebSite.DAL;
using JobsWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobsWebSite.Controllers
{
    
    public class RoleController : Controller
    {
        //
        // GET: /Role/
        DAL_Roles dal_role = new DAL_Roles();
       
        [HttpGet]
        public ActionResult Index()
        {
            if (AccountController.userid != 0 && AccountController.usertype == "Admin")
            {
                List<Role> roles = dal_role.AllRolesObjects();
                return View(roles);
            }
            else { return RedirectToAction("Login", new { controller = "Account", action = "Login" }); }
        }
        //////////////create//////////////
        
        [HttpGet]
        public ActionResult Create()
        {
            if (AccountController.userid != 0 && AccountController.usertype == "Admin")
            {
                return View();
            }
            else { return View("Login", new { controller = "Account", action = "Login" }); }
        }
        [HttpPost]
        public ActionResult Create(Role role)
        {
            
                dal_role.Roles(role);
                return View();
           
        }
        ////////////////Edit///////////
       
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Role role = dal_role.RoleDetails(id);
            if (AccountController.userid != 0 && AccountController.usertype == "Admin")
            {
                return View(role);
            }
            else { return RedirectToAction("Login", new { controller = "Account", action = "Login" }); }
            
        }
        [HttpPost]
        public ActionResult Edit(Role role)
        {
            dal_role.EditRole(role);
            return RedirectToAction("Index");
        }
        //////////////details//////////
        
        [HttpGet]
        public ActionResult Details(int id)
        {
            if (AccountController.userid != 0 && AccountController.usertype == "Admin")
            {
                Role role = dal_role.RoleDetails(id);
                return View(role);
            }
            else { return View("Login", new { controller = "Account", action = "Login" }); }
        }
        ///////////////////////Delete//////////
        
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (AccountController.userid != 0 && AccountController.usertype == "Admin")
            {
                Role role = dal_role.RoleDetails(id);
                return View(role);
            }
            else { return View("Login", new { controller = "Account", action = "Login" }); }

        }
        [HttpPost]
        public ActionResult Delete(Role role)
        {
            dal_role.RemoveRole(role.Id);

            return RedirectToAction("Index");
        }


           
    }
}
