using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VoterInformationSystemApplication.Controllers
{
    public class HomeController : Controller
    {

        VoterRepository voterRepository= new VoterRepository();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection loginForm)
        {
            string emailId = loginForm["txtEmailId"];
            string password = loginForm["txtPassword"];

            AdminUser adminUser = voterRepository.ValidateUser(emailId, password);

            if(adminUser == null )
            {
                ViewBag.ErrorMsg = "Invalid Credentials";
                return View("Login");
            }
            else
            {
                Session["EmailId"] = emailId;
                Session["AdminId"] = adminUser.ID;

                return RedirectToAction("Index","Voter");
            }
        }

    }
}