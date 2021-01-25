using Microsoft.AspNetCore.Mvc.Rendering;
using ProductsValidation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsValidation.ViewModels
{
    public class ProductPricesByCategoryVM
    {
        public List<Product> Products { get; set; }
        public SelectList Categories { get; set; }
    }
}
