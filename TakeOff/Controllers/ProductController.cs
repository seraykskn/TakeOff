using DataModel;
using RepositoryData;
using RepositoryData.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TakeOff.Controllers
{
    public class ProductController : YetkiliController
    {  
        private IRepository<Product> repository;
        private IRepository<User> user;
        private IRepository<Image> image;
        public ProductController()
        {
            this.repository = new EFRepository<Product>(new ContextClass());
            this.image = new EFRepository<Image>(new ContextClass());
            this.user = new EFRepository<User>(new ContextClass());
        }
        // GET: Product
        public ActionResult Index()
        {
            var model = repository.GetAll().ToList();
            return View(model);
            
        }
        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var products = repository.FindBy(i => i.ProductId == id).SingleOrDefault();
            return View(products);
        }
        public ActionResult ProductList()
        {
            try
            {
                string Mail = Session["Mail"].ToString();
                var products = repository.GetAll().ToList();

                return View(products);
                   }
                
                
            catch (Exception e)
            {
                string a = e.Message;
                return View();
            }
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product model,HttpPostedFileBase file,Image imageModel)
        {
            try
            {
                #region
                if (ModelState.IsValid)
                { 
                    string Mail = Session["Mail"].ToString();
                    var User = user.FindBy(i => i.Mail == Mail).SingleOrDefault();
                   
                    model.UserId = User.UserId;

                    if (file != null)
                    {   
                        //model.ImageUrl = file.FileName;
                        string fileName = Path.GetFileNameWithoutExtension(model.ImageUrl);
                        string extension = Path.GetExtension(model.ImageUrl);
                        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        model.ImageUrl = "~/images/" + fileName;
                        fileName = Path.Combine(Server.MapPath("~/images/"), fileName);
                        file.SaveAs(fileName);
                        
                        
                        //file.SaveAs(HttpContext.Server.MapPath("~/images/") + fileName);
                       
                        imageModel.ImageName = file.FileName;
                        
                        imageModel.ImageUrl = HttpContext.Server.MapPath("~/images/")+file.FileName;
                        image.Add(imageModel);
                        image.Save(imageModel);
                        model.YetkiId = 2;
                        repository.Add(model);  
                        repository.Save(model);
                        
                        return RedirectToAction("Profil", "User");

                    }
                }
              return View(model);
                }
               
                #endregion 
            catch (Exception e)
            {
                string a = e.Message;
                return View();
            }
        }
      
        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
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

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
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
