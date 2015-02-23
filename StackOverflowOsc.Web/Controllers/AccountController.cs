﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using StackOverflow.data;
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
                var Context = new StackOverflowContext();
                Context.Accounts.Add(newAccount);
                Context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(AccountLoginModel modelLogin)
        {
            var Context = new StackOverflowContext();
            var account = Context.Accounts.FirstOrDefault(x=>x.Email == modelLogin.Email && x.Password==modelLogin.Password);
            if (account != null)
            {
                FormsAuthentication.SetAuthCookie(modelLogin.Email, false);
                return RedirectToAction("Index", "Question");
            }
            return View(modelLogin);
        }

        public ActionResult Login()
        {
            return View(new AccountLoginModel());
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Question");
        }


        public ActionResult Profile(Guid id)
        {
            var Context = new StackOverflowContext();
            var account = Context.Accounts.FirstOrDefault(x => x.ID == id);
            if (account != null)
            {
                AutoMapper.Mapper.CreateMap<AccountProfileModel, Account>().ReverseMap();
                AccountProfileModel newAccount = AutoMapper.Mapper.Map<Account, AccountProfileModel>(account);
                return View(newAccount);
            }
            return View(new AccountProfileModel());
        }

        public ActionResult PassWordRecovery()
        {
            return View(new ForgotPasswordRecoveryModel());
        }

        [HttpPost]
        public ActionResult ForgotPasswordRecovery(ForgotPasswordRecoveryModel modelPass)
        {
            return RedirectToAction("ForgotPasswordRecovery");
        }
    }
}
