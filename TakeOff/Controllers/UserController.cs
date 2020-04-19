using DataModel;
using RepositoryData;
using RepositoryData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace TakeOff.Controllers
{
    public class UserController : YetkiliController
    {
        private IRepository<User> repository;

        public UserController()
        {
            this.repository = new EFRepository<User>(new ContextClass());
        }
        // GET: User
        public ActionResult Index(User model)
        {
            string Mail = Session["Mail"].ToString();
            var User = repository.FindBy(i => i.Mail == Mail).SingleOrDefault();

            return View(User);
        }
        public ActionResult Profil(User model)
        {
            string Mail = Session["Mail"].ToString();
            var User = repository.FindBy(i => i.Mail == model.Mail).SingleOrDefault();
            return View(User);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }


        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {

            //string kullaniciAdi = Session["username"].ToString();
            //var user = db.Kullanicis.Where(i => i.kullaniciAdi == kullaniciAdi).SingleOrDefault();
            //if (OrtakSinif.EditIsimYetkiVarMi(id, user))
            //{
            //    var kisi = db.Kullanicis.Where(i => i.id == id).SingleOrDefault();
            //    return View(kisi);
            //}
            return HttpNotFound();
            
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
