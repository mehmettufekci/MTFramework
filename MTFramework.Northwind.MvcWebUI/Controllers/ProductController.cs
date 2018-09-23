using MTFramework.Northwind.Business.Abstract;
using MTFramework.Northwind.Entities.Concrete;
using MTFramework.Northwind.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MTFramework.Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: Product
        public ActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };

            return View(model);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            
            Product product = _productService.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
           
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
           
            Product product = _productService.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
           
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = _productService.GetById(id);
            _productService.Delete(product);
            return RedirectToAction("Index");
        }
    }
}