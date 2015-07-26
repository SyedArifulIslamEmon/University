using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Univercity_Project.Models;
using Univercity_Project.Models.Models;

namespace Univercity_Project.Controllers
{
    [Authorize(Roles = "Admin,Moderator")]
    public class SearchController : Controller
    {

        public SearchController(UserManager<Employee> userManager)
        {
            Usermanager = userManager;
        }

        public SearchController()
        {
            contex = new MyDbContext();
            Usermanager = new UserManager<Employee>( new UserStore<Employee>(contex));
        }

        public UserManager<Employee> Usermanager {get;private set;}
        public MyDbContext contex { get; private set; }

        //
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET : /Search/Search_By_Name
        [HttpGet]
        public ActionResult Search_By_Name()
        {          
                return View();                     
        }

        //
        //POST : /Search/Search_By_Name
        [HttpPost]
        public ActionResult Search_By_Name(string first_name, string last_name)
        {
            if (String.IsNullOrEmpty(first_name) && String.IsNullOrEmpty(last_name))
                return Json(null, JsonRequestBehavior.AllowGet);

            var users = contex.Users.AsQueryable();

            if (!String.IsNullOrEmpty(first_name))
                users = users.Where(x => x.First_Name.Contains(first_name));

            if (!String.IsNullOrEmpty(last_name))
                users = users.Where(x => x.Last_Name.Contains(last_name));

            var result = users.Select(x => new
            {
                x.Employment_Number,
                x.First_Name,
                x.Last_Name,
                x.Id,
            })
            .ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //
        // GET :/Search/Search_By_Employment_Number
        [HttpGet]
        public ActionResult Search_By_Employment_Number()
        {
            return View();
        }

        //
        // POST :/Search/Search_By_Employment_Number
        [HttpPost]
        public async Task<ActionResult> Search_By_Employment_Number(string emp_num)
        {
            if (emp_num != null)
            {
                // Username = EmpymentNumber
                var result = await Usermanager.FindByNameAsync(emp_num);
                return Json(new {firstname = result.First_Name , lastname = result.Last_Name, empnum = result.Employment_Number,id = result.Id },JsonRequestBehavior.AllowGet);
            }
            return View();
        }

    }
}