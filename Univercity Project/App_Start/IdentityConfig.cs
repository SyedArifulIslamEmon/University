using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Univercity_Project.Models;
using Univercity_Project.Models.Models;

namespace Univercity_Project.App_Start
{
    class MyDbInitializer : DropCreateDatabaseIfModelChanges<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
            InitializeIdentityForEF(context);
            base.Seed(context);
        }

        private void InitializeIdentityForEF(MyDbContext context)
        {
            var UserManager = new UserManager<Employee>(new UserStore<Employee>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            //Create A User
            var myUser = new Employee() 
            {
                Employment_Number= "900600426", 
                Gender = "Male",
                National_ID = 0430077866,
                First_Name = "امیرمسعود",
                Last_Name = "رمضانی",
                Father_Name = "رضا",
                Birth_Place = "دماوند",
                Birth_Date = new DateTime(1994,04,13),
                Serial_Alphabetic = "الف",
                Serial_Numeric = 478963,
                Number_of_People_Under_Support = 0
            };
            myUser.UserName = myUser.Employment_Number;
            myUser.Employment_Status_ID = 1;
            myUser.Marriage_Status_ID = 1;
            myUser.Academic_Status = new Academic_Status {Major = "کامپیوتر" , Branch = "نرم افزار" , Degree = "لیسانس", Date_OF_Recieving_Degree = new DateTime(2016,09,26) };
            myUser.Address = new Address { Avenue="فروردین", City="دماوند", First_Street="مطهری", House_Number= 5,  Post_Code= "478963"};
            myUser.Insuarance_Info = new Insuarance { Code_Of_Factory_Request_Insuarance = "10", Insuarance_Code = "10225", Name_Of_Factory_Request_Insuarance = "فن آوا", Type_Of_Insuarance = "بیمه خدمات درمانی" };
            myUser.Job_Status = new Job_Status { Job_Group="غیر دولتی", Job_Title="توسعه دهنده", Location="تهران", Unit="زیرساخت" };
            myUser.Phone_Number = new Phone_Number { Home=76321011, Mobile= 09122225698, Work= 76523698 };
            
            //Create Role "Admin" & Add myUser To Admin Role

            if(!RoleManager.RoleExists("Admin"))
            {
                RoleManager.Create(new IdentityRole("Admin"));
            }

            if (!RoleManager.RoleExists("Moderator"))
            {
                RoleManager.Create(new IdentityRole("Moderator"));
            }

            if (!RoleManager.RoleExists("User"))
            {
                RoleManager.Create(new IdentityRole("User"));
            }

            var Userresult = UserManager.Create(myUser, "0430077866");
            if(Userresult.Succeeded)
            {
                var result = UserManager.AddToRole(myUser.Id,"Admin");
            }
        }
    }
}
