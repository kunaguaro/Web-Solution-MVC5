using AppWebGen.Service.Services;
using AppWebGen.Service.Validators;
using FluentValidation.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppGen.Infrastructure;
using WebAppGen.Model.Entities;
using WebAppGeneric.ViewModel;

namespace WebAppGeneric.Controllers
{
    public class CountriesController : Controller
    {
        private WebAppContext db = new WebAppContext();
        ICountryService countryService;


        public CountriesController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        // GET: Countries
        public ActionResult Index()
        {
            
            return View(countryService.GetAll().ToList());
           // return View(db.Countries.ToList());
        }


        public ActionResult ListaJQuery()
        {

            return View();
          
        }

        public ActionResult LoadDataTable(DataTableRequest model)
        {

            //Creamos un objeto data DataTableAdapter con el model view que vamos a mostrar.
            DataTableAdapter<Country> result = new DataTableAdapter<Country>();
            //Obtenemos el total de registros de la tabla.
            var totalRows = countryService.GetAll().Count();


            Func<Country, Object> orderByFunc = null;
            //El ordenamiento que vamos a utilizar por default va ser por el Id.
            orderByFunc = item => item.Id;

            //Dependiendo de la columna que seleccionemos indicamos si se ordena por el campo Description.
            if (model.order[0]["column"].Equals("1"))
            {
                orderByFunc = item => item.Name;
            }
          
            //Obtenemos el valor a buscar.
            string searchValue = "" + model.search["value"] + "";
            List<Country> lista = new List<Country>();
            lista = countryService.GetAll().ToList();
            var queryItem = lista.Where(d => d.Name.ToLower().Contains(searchValue.ToLower()));
            List<Country> items;
            //Indicamos cual va ser la manera en que se van a ordenar los datos.
            if (model.order[0]["dir"].Equals("desc"))
            {
                items = queryItem.OrderByDescending(orderByFunc).Skip(model.start).Take(model.length).ToList();
            }
            else
            {
                items = queryItem.OrderBy(orderByFunc).Skip(model.start).Take(model.length).ToList();

            }

            //Llenamos con información nuestro DataTableAdapter
            result.Data = items;
            result.Draw = model.draw;
            result.RecordsTotal = totalRows;
            result.RecordsFiltered = queryItem.Count();
            //Regresamos la respuesta Json
            return Content(JsonConvert.SerializeObject(result), "application/json");



        }



        // GET: Countries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // GET: Countries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Countries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Country country)
        {
            CountryValidator validar = new CountryValidator();
            ValidationResult Result = validar.Validate(country);
            if (!Result.IsValid)
            {
                foreach (ValidationFailure item in Result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(country);
            }
            else
            {
                var objCountry = countryService.Insertar(country);
                return RedirectToAction("Index");
            }
        }

        // GET: Countries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // POST: Countries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Country country)
        {
            CountryValidator validar = new CountryValidator();
            ValidationResult Result = validar.Validate(country);
            if (!Result.IsValid)
            {
                foreach (ValidationFailure item in Result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(country);
            }
            else
            {
                var objCountry = countryService.Actualizar(country);
                return View(country);
            }
            //if (ModelState.IsValid)
            //{
            //    db.Entry(country).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(country);
        }

        // GET: Countries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = countryService.GetById(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Country country = db.Countries.Find(id);
            //if (country == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(country);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            int proceso = countryService.Delete(id);
            return RedirectToAction("Index");
            //Country country = db.Countries.Find(id);
            //db.Countries.Remove(country);
            //db.SaveChanges();
            //return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
