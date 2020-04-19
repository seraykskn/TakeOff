﻿using DataModel;
using RepositoryData;
using RepositoryData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TakeOff.Controllers
{
    public class YetkiliController : Controller
    {
         private IRepository<User> repository;

        public YetkiliController()
        {
            this.repository = new EFRepository<User>(new ContextClass());
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["Mail"] == null)
            {
                filterContext.Result = new HttpNotFoundResult();
                return;
            }
            base.OnActionExecuting(filterContext);
        }
        public ActionResult Hata(string yazilacak)
        {
            ViewBag.yaz = yazilacak;
            return View(yazilacak);

        }
    }
}
