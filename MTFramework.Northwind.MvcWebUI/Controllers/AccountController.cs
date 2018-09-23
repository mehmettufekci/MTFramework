using MTFramework.Core.CrossCuttingConcerns.Security.Web;
using MTFramework.Northwind.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MTFramework.Northwind.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Account
        public String Login(string userName, string password)
        {
            var user = _userService.GetByUserNameAndPassword(userName, password);
            if (user != null)
            {
                AuthenticationHelper.CreateAuthCookie(
                new Guid(), user.UserName,
                user.Email,
                DateTime.Now.AddDays(15),
                new[] { "Student" },
               false,
              user.FirstName,
                user.LastName);
                return "User is authenticated!";
            }

            return "User is NOT authenticated!";
        }
    }
}