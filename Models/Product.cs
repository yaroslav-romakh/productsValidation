using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsValidation.Models
{
    public class Product
    {
        public enum Category { Toy, Technique, Clothes, Transport }

        public int Id { get; set; }
        public Category Type { get; set; }
        [Required]
        public string Name { get; set; }
        [MinLength(3)]
        [ValidateStringProperty]
        public string Description { get; set; }
        [Range(0, 100000)]
        public int Price { get; set; }
    }

    public class ValidateStringPropertyAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string description = (string)value;
            var product = (Product)validationContext.ObjectInstance;
            if (!String.IsNullOrEmpty(description) && null != product)
            {
                if (product.Name == description || !description.StartsWith(product.Name))
                {
                    return new ValidationResult($"Description should not be equal to Name but " +
                                                $"it should start with the Name of the product");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            return null;
        }
    }
}
