using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniInternetMagazin.Db;
using MiniInternetMagazin.Models.GroceryStoreViewModels;

namespace MiniInternetMagazin.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult SelectProducts()
        {
            using (var context = new DataContext())
            {
                return View(context.Products.ToList<Product>());
            }
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            try
            {
                using (var context = new DataContext())
                {
                    context.Products.Add(product);
                    if (context.SaveChanges() > 0)
                        return Ok("Успешно добавлен!");
                }
            }
            catch (Exception ex)
            {
                return View($"{ex.Message}");
            }
            return BadRequest("Не добавлен!");
        }
        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int productId)
        {
            try
            {
                using (var context = new DataContext())
                {
                    var res = context.Products.FirstOrDefault<Product>(p => p.ProductId == productId);
                    if (res != null)
                    {
                        context.Products.Remove(res);
                    }
                    if (context.SaveChanges() > 0)
                        return Ok("Успешно удален!");
                }
            }
            catch (Exception ex)
            {
                return View($"{ex.Message}");
            }
            return BadRequest("Продукт по такой Id не существует!");
        }
        [HttpGet]
        public ActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Update(Product product)
        {
            try
            {
                using (var context = new DataContext())
                {
                    Product res = context.Products.FirstOrDefault<Product>(p => p.ProductId == product.ProductId);
                    if (res != null)
                    {
                        res.ProductName = product.ProductName;
                        res.Price = product.Price;
                        context.Products.Update(res);
                    }
                    if (context.SaveChanges() > 0)
                        return Ok("Успешно измененo");
                }
            }
            catch (Exception ex)
            {
                return View($"{ex.Message}");
            }
            return BadRequest("Продукт по такой Id не существует!");

        }

    }
}