using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Min18IfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var Customer = (customer)validationContext.ObjectInstance;

            if (Customer.MembershipTypeId == MembershipType.UnKnown || Customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (Customer.Birthdate == null)
                return new ValidationResult("Birthdate is required");

            var age = DateTime.Today.Year - Customer.Birthdate.Value.Year;
            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Customer to be atleast 18 to be a MemberShip");
        }
    }
}