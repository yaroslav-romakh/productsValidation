using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsValidation.Models;

namespace ProductsValidation.Services
{
    public class Data
    {
        public List<Product> Products = new List<Product>
        {
            new Product() {Id = 1, Name = "Product2", Description = "ProductDescription", Type = Product.Category.Clothes, Price = 100 },
            new Product() {Id = 2, Name = "Product3", Description = "ProductDescription", Type = Product.Category.Technique, Price = 130 },
            new Product() {Id = 3, Name = "Product4", Description = "ProductDescription", Type = Product.Category.Technique, Price = 450 },
            new Product() {Id = 4, Name = "Product5", Description = "ProductDescription", Type = Product.Category.Transport, Price = 230 },
            new Product() {Id = 5, Name = "Product6", Description = "ProductDescription", Type = Product.Category.Transport, Price = 700 },
            new Product() {Id = 6, Name = "Product1", Description = "ProductDescription", Type = Product.Category.Transport, Price = 24 },
            new Product() {Id = 7, Name = "Product7", Description = "ProductDescription", Type = Product.Category.Toy, Price = 15 },
            new Product() {Id = 8, Name = "Product8", Description = "ProductDescription", Type = Product.Category.Toy, Price = 20 },
            new Product() {Id = 9, Name = "Product9", Description = "ProductDescription", Type = Product.Category.Toy, Price = 80 },
            new Product() {Id = 10, Name = "Product10", Description = "ProductDescription", Type = Product.Category.Toy, Price = 20 }
        };

        public List<User> Users = new List<User>
        {
            new User() {Id = 1, Name = "UserAdmin", Email = "admin@gmail.com", Role = "admin"},
            new User() {Id = 2, Name = "Guest", Email = "guest@gmail.com", Role = "guest"},
            new User() {Id = 3, Name = "User", Email = "user1@gmail.com", Role = "user"},
            new User() {Id = 4, Name = "User2", Email = "user2@gmail.com", Role = "user"},

        };
    }
}
