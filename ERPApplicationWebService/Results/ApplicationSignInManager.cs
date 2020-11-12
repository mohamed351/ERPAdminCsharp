using ERPApplicationWebService.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace ERPApplicationWebService.Results
{
    //public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    //{
    //    private ApplicationUserManager applicationUserManager;
    //    private IOwinContext context;

    //    public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
    //        : base(userManager, authenticationManager)
    //    {
    //    }

     

    //    public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
    //    {
    //        return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
    //    }

    //    public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
    //    {
    //        ApplicationSignInManager us = new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);

    //        return us;
    //    }
    //}

   
}