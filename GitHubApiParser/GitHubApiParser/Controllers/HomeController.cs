using GitHubApiParser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GitHubApiParser.Controllers
{
    public class HomeController : Controller
    {
        GitHubApiParser.Services.GithubService _githubservice;

        // TODO: With a bit more time i should have implemented the dependency injection 
        // to pass the service to the controller
        public HomeController()
        {
            _githubservice = new Services.GithubService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAccountInfo(string search)
        {
            UserInfo result = _githubservice.GetUserInfo(search);

            if(result == null)
            {
                ViewBag.ErrorMessage = "Account was not found";
                return View("Error");
            }

            return View("Results", result);
        }
    }
}