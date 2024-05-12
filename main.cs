using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace ldap.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


      

         public ActionResult Panel()
         {
             ViewBag.Message = "Your contact page.";

             return View();
         }


        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            if (ValidateCredentials(username, password))
            {
                // If the user is valid, set up the forms authentication ticket here and redirect as necessary
                FormsAuthentication.SetAuthCookie(username, false);
                return RedirectToAction("Panel", "Home");
            }
            else
            {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return RedirectToAction("Index", "Home");
            }
        }

        private bool ValidateCredentials(string username, string password)
        {
            // Assuming "LDAP://YourDomain" is the path to your LDAP directory
            using (var context = new PrincipalContext(ContextType.Domain, "<PC-NAME:LDAP-Port>", "CN=jehad ahmad,CN=Users,DC=WIN,DC=jehad"))
            {
                // Perform actions, such as validating credentials
                return context.ValidateCredentials(username, password);
            }
        }

    }
}