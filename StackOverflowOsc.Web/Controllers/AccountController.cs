using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StackOverflowOsc.Domain.Entities;
using StackOverflowOsc.Web.Models;

namespace StackOverflowOsc.Web.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Register()
        {
            return View(new AccountRegisterModel());
        }

        public ActionResult ForgotPassword()
        {
            return View(new AccountForgotPasswordModel());
        }

        [HttpPost]
        public ActionResult Register(AccountRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                AutoMapper.Mapper.CreateMap<Account, AccountRegisterModel>().ReverseMap();
                Account newAccount = AutoMapper.Mapper.Map<AccountRegisterModel, Account>(model);
            }
            return View(model);
        }

        public ActionResult Login()
        {
            return View(new AccountLoginModel());
        }

        public ActionResult Profile(AccountProfileModel modelProfile)
        {
            return View(new AccountProfileModel());
        }
    }
}
