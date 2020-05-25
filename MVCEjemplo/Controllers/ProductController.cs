using MVCEjemplo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEjemplo.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            List<ProductModel> models = new List<ProductModel>();
            if (Session["Products"]==null)
            {             
                models.Add(new ProductModel { ProductID = 1, Name = "Laptop" });
                models.Add(new ProductModel { ProductID = 2, Name = "Mouse" });
                Session["Products"] = models;
            }
            else
            {
                models =(List<ProductModel>) Session["Products"];
            }
            return View(models);
        } 

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductModel model)
        {
            try
            {
                // TODO: Add insert logic here
                ((List<ProductModel>)Session["Products"]).Add(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            ProductModel model = ((List<ProductModel>)Session["Products"]).
                                  FirstOrDefault(x => x.ProductID == id);
            return View(model);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProductModel model)
        {
            try
            {
                // TODO: Add update logic here
                ProductModel modelAnt = ((List<ProductModel>)Session["Products"]).
                                  FirstOrDefault(x => x.ProductID == id);
                
                //Asignar valores nuevos
                modelAnt.ProductID = model.ProductID;
                modelAnt.IsEnable = model.IsEnable;
                modelAnt.Price = model.Price;
                modelAnt.Stock = model.Stock;
                modelAnt.Type = model.Type;
                modelAnt.Name = model.Name;



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
            ProductModel model = ((List<ProductModel>)Session["Products"]).
                                FirstOrDefault(x => x.ProductID == id);
            return View(model);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ProductModel model)
        {
            try
            {
                // TODO: Add delete logic here
                ProductModel modelAnt = ((List<ProductModel>)Session["Products"]).
                                 FirstOrDefault(x => x.ProductID == id);

                ((List<ProductModel>)Session["Products"]).Remove(modelAnt);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
