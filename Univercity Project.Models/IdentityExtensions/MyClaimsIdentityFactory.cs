using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Univercity_Project.Models.IdentityExtensions
{
    public class MyClaimsIdentityFactory<TUser> : ClaimsIdentityFactory<TUser> where TUser : class , IUser<string>
    {
        internal const string IdentityProviderClaimType = "http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider";
        internal const string DefualtIdentityProviderClaimValue = "ASP.NET Identity";

        public MyClaimsIdentityFactory()
        {
            UserIdClaimType = ClaimTypes.NameIdentifier;
            UserNameClaimType = ClaimsIdentity.DefaultNameClaimType;
            LastLoginTimeType = "LoginTime";
        }

        public async override Task<ClaimsIdentity> CreateAsync(UserManager<TUser, string> manager, TUser user, string authenticationType)
        {
            //3 Default Claim
            var id = new ClaimsIdentity(authenticationType, UserNameClaimType, null);
            id.AddClaim(new Claim(UserIdClaimType, user.Id.ToString(), ClaimValueTypes.String));
            id.AddClaim(new Claim(UserNameClaimType, user.UserName.ToString(), ClaimValueTypes.String));
            id.AddClaim(new Claim(IdentityProviderClaimType, DefualtIdentityProviderClaimValue, ClaimValueTypes.String));

            //Login time as Claim
            id.AddClaim(new Claim(LastLoginTimeType, DateTime.Now.ToString()));

            if (manager.SupportsUserClaim)
            {
                id.AddClaims(await manager.GetClaimsAsync(user.Id));
            }
            return id;

        }

        public string UserIdClaimType { get; set; }
        public string UserNameClaimType { get; set; }
        public string LastLoginTimeType { get; set; }
    }
}
