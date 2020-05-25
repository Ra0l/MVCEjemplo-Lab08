using MVCEjemplo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEjemplo.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            List<MovieModel> models = new List<MovieModel>();
            //Ir a la base de datos a llenar a la lista de models

            if (Session["Movies"] == null)
            {
                models.Add(new MovieModel { MovieID = 1, Title = "Cinemark", Price = 35 });
                models.Add(new MovieModel { MovieID = 2, Title = "CinePlanet", Price = 40 });
                Session["Movies"] = models;
            }
            else
            {
                models = (List<MovieModel>)Session["Movies"];
            }

            return View(models);
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create(MovieModel model)
        {
            try
            {
                // TODO: Add insert logic here
                ((List<MovieModel>)Session["Movies"]).Add(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            MovieModel model = ((List<MovieModel>)Session["Movies"]).
                                FirstOrDefault(x => x.MovieID == id);
            return View(model);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MovieModel model)
        {
            try
            {
                // TODO: Add update logic here
                MovieModel modelAnt = ((List<MovieModel>)Session["Movies"]).
                                FirstOrDefault(x => x.MovieID == id);

                //Asignar valores nuevos 
                modelAnt.MovieID = model.MovieID;
                modelAnt.Title = model.Title;
                model.Price = model.Price;


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            MovieModel model = ((List<MovieModel>)Session["Movies"]).
                                FirstOrDefault(x => x.MovieID == id);
            return View(model);
        }

        // POST: Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, MovieModel model)
        {
            try
            {
                // TODO: Add delete logic here
                MovieModel modelAnt = ((List<MovieModel>)Session["Movies"]).
                                FirstOrDefault(x => x.MovieID == id);

                ((List<MovieModel>)Session["Movies"]).Remove(modelAnt);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
