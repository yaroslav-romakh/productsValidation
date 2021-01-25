using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using ProductsValidation.Models;
using ProductsValidation.Services;
using ProductsValidation.ViewModels;

namespace ProductsValidation.Controllers
{
    
    public class ProductsController : Controller
    {
        private List<Product> myProducts;

        public ProductsController(Data data)
        {
            myProducts = data.Products;
        }
        
        public IActionResult Index(int filterId, string filtername)
        {
            return View(myProducts);
        }
        
        public IActionResult View(int id)
        {
            Product prod = myProducts.Find(prod => prod.Id == id);
            if (prod != null)
            {
                return View(prod);
            }

            return View("NotExists");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product prod = myProducts.Find(prod => prod.Id == id);
            if (prod != null)
            {
                return View(prod);
            }

            return View("NotExists");
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            myProducts[myProducts.FindIndex(prod => prod.Id == product.Id)] = product;
            if (null != product.Name && null != product.Description)
            {
                if (product.Name == product.Description ||
                !product.Description.StartsWith(product.Name))
                {
                    return View(product);
                }
                else
                {
                    return View("View", product);
                }
            }
            else
            {
                return View("View", product);
            }
        }

        [HttpGet]
        public IActionResult EditPricesByCategory(Product.Category ? category = null)
        {
            var products = (null != category) ? 
                myProducts.Where(prod => prod.Type == category).ToList() : myProducts ;

            ProductPricesByCategoryVM productPricesByCategoryVM = new ProductPricesByCategoryVM()
            {
                Products = products,
                Categories = new SelectList(myProducts.Select(x => x.Type).Distinct())
            };

            return View(productPricesByCategoryVM);
        }

        [HttpPost]
        public IActionResult EditPricesByCategory(List<Product> products)
        {
            foreach (var product in products)
            {
                myProducts[myProducts.FindIndex(prod => prod.Id == product.Id)].Price = product.Price;
            }

            return View("Index", myProducts);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (null != product.Name && null != product.Description)
            {
                if (product.Name == product.Description ||
                    !product.Description.StartsWith(product.Name))
                {
                    return View(product);
                }
                else
                {
                    myProducts.Add(product);
                    return View("View", product);
                }
            }
            else
            {
                myProducts.Add(product);
                return View("View", product);
            }
        }

        public IActionResult Create()
        {
            Product product = new Product();
            product.Id = (myProducts.Count > 0) ? myProducts.Max(prod => prod.Id) + 1 : product.Id = 1;
            return View(product);
        }

        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                myProducts.Remove(myProducts.Find(product => product.Id == id));
            }
            return View("Index", myProducts);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
