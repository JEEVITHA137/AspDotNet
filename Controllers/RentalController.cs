using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication4.Dtos;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class RentalController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Rental> GetCustomers()
        {
            var rental = _context.Rentals.ToList();
            return (rental);
        }
        [HttpPost]
        public IHttpActionResult CreateNewRentals(RentalDto newRental)
        {
         
            var customer1 = _context.Customers.SingleOrDefault(
                c => c.id == newRental.customerId);

            var movies = _context.Products.SingleOrDefault(
                m => m.Id == newRental.productId);
            if (movies.Stock == 0)
                  return BadRequest("Movie is not Available");
            movies.NumberAvailable--;

            movies.Stock--;

            var rental = new Rental
            {
                    customer = customer1,
                    product = movies,
                    DateRented = DateTime.Now
            };

           _context.Rentals.Add(rental);
           _context.SaveChanges();
            return Ok();
        }
    }

}
