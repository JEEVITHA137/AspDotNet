using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class StockBtwn:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var Movie = (product)validationContext.ObjectInstance;

            return (Movie.Stock != 0)
                ? ValidationResult.Success
                : new ValidationResult("The Stock need atleast 1 as a minimum value");
        }
    }
}