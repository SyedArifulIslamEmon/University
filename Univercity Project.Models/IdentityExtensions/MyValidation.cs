using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Univercity_Project.Models.IdentityExtensions
{
    public class MyUserValidation : IIdentityValidator<Employee>
    {
        public System.Threading.Tasks.Task<IdentityResult> ValidateAsync(Employee item)
        {
            if (item.UserName.ToLower().Length != 10)
                return
                    Task.FromResult(IdentityResult.Failed(" شماره پرسنلی باید 10 رقم باشد "));
            else
                return Task.FromResult(IdentityResult.Success);
        }
    }

    public class MyPasswordValidation : IIdentityValidator<string>
    {
        public Task<IdentityResult> ValidateAsync(string item)
        {
            if (item.ToLower().Contains("111111"))
                return
                    Task.FromResult(IdentityResult.Failed("کلمه عبور نمیتواند شش 1 پشت هم باشد"));
            else
                return Task.FromResult(IdentityResult.Success);
        }
    }
}
