using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Univercity_Project.Models;
using Univercity_Project.Models.IdentityExtensions;
using Univercity_Project.Models.Models;
using Univercity_Project.Models.ViewModels;

namespace Univercity_Project.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public AccountController()
            :this (new UserManager<Employee>(new UserStore<Employee>(new MyDbContext())))
        {

        }

        public AccountController(UserManager<Employee> userManager)
        {
            UserManager = userManager;
        }

        public UserManager<Employee> UserManager { get; private set; }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(Login_ViewModel model, string returnUrl)
        {
            if(ModelState.IsValid)
            {
                var user = await UserManager.FindAsync(model.Employment_Number, model.Password);
                if(user != null)
                {
                    await SignInAsync(user, model.RememberMe);
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "نام کاربری یا کلمه عبور اشتباه است!");
                }
            }
            return View(model);
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        //
        //POST : /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(Register_ViewModel model)
        {
            UserManager.UserValidator = new MyUserValidation();

            //Complete User Object if Model is Valid
            if (ModelState.IsValid)
            {
                Employee user = new Employee {
                    UserName = model.Employment_Number ,
                    Birth_Date = model.Birth_Date ,
                    Birth_Place = model.Birth_Place,
                    First_Name = model.First_Name, 
                    Father_Name = model.Father_Name ,
                    Last_Name = model.Last_Name,
                    Employment_Number = model.Employment_Number,                  
                    National_ID = model.National_ID,
                    Serial_Alphabetic = model.Serial_Alphabetic, 
                    Serial_Numeric = model.Serial_Numeric,
                    Number_of_People_Under_Support = model.Number_of_People_Under_Support,
                    Academic_Status = new Academic_Status(),
                    Address = new Address(),
                    War_Record_Info = new War_Record(),
                    Insuarance_Info = new Insuarance(),
                    Phone_Number = new Phone_Number(),
                    Job_Status = new Job_Status()
                };

                switch(model.Gender)
                {
                    case 1:
                        user.Gender = "مرد";
                        break;
                    case 2:
                        user.Gender = "زن";
                        break;
                }             

                user.Phone_Number.Home = model.Home;
                user.Phone_Number.Mobile = model.Mobile;
                user.Phone_Number.Work = model.Work;

                user.Academic_Status.Major = model.Major;
                user.Academic_Status.Degree = model.Degree;
                user.Academic_Status.Branch = model.Branch;
                user.Academic_Status.Date_OF_Recieving_Degree = model.Date_OF_Recieving_Degree;

                user.Job_Status.Job_Group = model.Job_Group;
                user.Job_Status.Job_Title = model.Job_Title;
                user.Job_Status.Location = model.Location;
                user.Job_Status.Unit = model.Unit;                

                user.Insuarance_Info.Insuarance_Code = model.Insuarance_Code;
                user.Insuarance_Info.Code_Of_Factory_Request_Insuarance = model.Code_Of_Factory_Request_Insuarance;
                user.Insuarance_Info.Name_Of_Factory_Request_Insuarance = model.Name_Of_Factory_Request_Insuarance;
                user.Insuarance_Info.Type_Of_Insuarance = model.Type_Of_Insuarance;

                user.Address.Avenue = model.Avenue;
                user.Address.Block_Number = model.Block_Number;
                user.Address.City = model.City;
                user.Address.District = model.District;
                user.Address.First_Street = model.First_Street;
                user.Address.Seconde_Street = model.Seconde_Street;
                user.Address.House_Number = model.House_Number;
                user.Address.Post_Code = model.Post_Code;

                user.Employment_Status_ID = model.Employment_Type;
                user.Marriage_Status_ID = model.Marriage_Status;

                if (model.Military_Record_Yes)
                {
                    user.War_Record_Info.Date_Captured = model.Date_Captured;
                    user.War_Record_Info.Date_Finish_Serving = model.Date_Finish_Serving;
                    user.War_Record_Info.Date_Start_Serving = model.Date_Start_Serving;
                    user.War_Record_Info.Disable_Percentage = model.Disable_Percentage;
                    user.War_Record_Info.Military_Record = model.Military_Record_Yes; 
                }

                user.Marriage_Status_ID = 1;
                user.Employment_Status_ID = 1;

                user.War_Record_Info.Desendents_Of_Martyr = model.Desendents_Of_Martyr_Yes;
             
                //Store Claims
                user.Claims.Add(new IdentityUserClaim() { ClaimType = ClaimTypes.SerialNumber, ClaimValue = model.Employment_Number,UserId = user.Id });
                user.Claims.Add(new IdentityUserClaim() { ClaimType = ClaimTypes.Gender, ClaimValue = user.Gender, UserId = user.Id });
              
                    var result = await UserManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {                    
                        await UserManager.AddToRoleAsync(user.Id, "User");
                        await SignInAsync(user, IsPersistent: false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        AddErrors(result);
                    }                              
            }
            return View(model);
        }

        //
        //GET : /Account/Manage
        [HttpGet]
        public ActionResult Manage (ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                 message == ManageMessageId.ChangePasswordSuccess ? "رمز با موفقیت تغییر کرد"
                 : message == ManageMessageId.SetPasswordSuccess ? "رمز با موفقیت تنظیم شد"
                 : message == ManageMessageId.Error ? "مشکلی بوجود آمده! لطفا دوباره تلاش کنید"
                 : "";
            var temp = HasPassword();
            ViewBag.HasLoaclPassword = temp; 
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View();
        }

        //
        //POST : /Account/Manage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> Manage(Manage_User_ViewModel model)
        {
            bool haspassword = HasPassword();
            ViewBag.HasLocalPassword = haspassword;
            ViewBag.ReturnUrl = Url.Action("Manage");
            if (haspassword)
            {
                if (ModelState.IsValid)
                {
                    IdentityResult result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
                    }
                    else
                    {
                        AddErrors(result);
                    }
                }
            }
            else
            {
                ModelState state = ModelState["OldPassword"];
                if (state != null)
                {
                    state.Errors.Clear();
                }
                if (ModelState.IsValid)
                {
                    IdentityResult result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Manage", new { Message = ManageMessageId.SetPasswordSuccess });
                    }
                    else
                    {
                        AddErrors(result);
                    }
                }
            }
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
        
    
        
                      

        #region Helpers

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private async Task SignInAsync(Employee user , bool IsPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            var claim = new Claim(ClaimTypes.SerialNumber, user.Employment_Number);
            identity.AddClaim(claim);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = IsPersistent }, identity);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach(var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            Error
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        #endregion
    }
}