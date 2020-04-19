using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepositoryData;
using DataModel;
using RepositoryData.Repositories;
namespace TakeOff.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<User> repository;

        public HomeController()
        {
            this.repository = new EFRepository<User>(new ContextClass());
        }
 
        // GET: User
        public ActionResult Index()
        {
            var model = repository.GetAll();
            //return View(User);
            return View(model);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string txtMail, string txtPassword)
        {
            try
            {
                var User = repository.FindBy(i => i.Mail == txtMail).SingleOrDefault();
                if (User == null)
                {
                    return View();
                }
                if (User.Password == txtPassword)
                {
                    Session["Mail"] = txtMail;
                    
                    return RedirectToAction("Index", "User"); //UserController için index olacak.

                }

                else
                {
                    return View();
                }
            }
            catch
            {
                string jsonData = Request.Form[0];
                return View();
            }
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            var model= new User();
            return View(model);
        }
        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User model)
        { try
            {
                var varMi = repository. FindBy(i => i.Mail == model.Mail).SingleOrDefault();
                if(varMi!=null)
                {
                    return View();
                }
                if (string.IsNullOrEmpty(model.Password))
                {
                    return View();
                }

                model.YetkiId = 1;
                repository.Add(model);
                repository.Save(model);
                Session["Mail"] = model.Mail;

                return RedirectToAction("Index");
                #region
                // if (ModelState.IsValid)
               // {
               //    repository.Add(User);
               //    repository.Save(User);

               //   return RedirectToAction("Index");
                //}
                #endregion
            }
            catch(Exception e)
            {
                string a = e.Message;
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var User = repository.FindByID(id);
            return View(User);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,User User)
        { try
            {
                repository.Update(User);
                repository.Save(User);

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
            var User = repository.FindByID(id);
            return View(User);  
        }
        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,User User)
        { try
            {   repository.Delete(User);
                repository.Save(User);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
