using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication4.Dtos;
using WebApplication4.Models;
using System.Data.Entity;
using AutoMapper;

namespace WebApplication2.Controllers
{
    public class CustomerController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customer
        public IHttpActionResult GetCustomers(string query=null)
        {
            var customerQuery = _context.Customers
                .Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                customerQuery = customerQuery.Where(c => c.Name.Contains(query));

            var customerDtos = customerQuery.ToList()
                .Select(Mapper.Map<customer, customerDto>);

            return Ok(customerDtos);
        }

        //GET /api/customer/1
        public IHttpActionResult GetCustomer(int id)
        {
            var Customer = _context.Customers.SingleOrDefault(c => c.id == id);
       
            if (Customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(Mapper.Map<customer, customerDto>(Customer));
        }

        //POST /api/customer/1
        [HttpPost]
        public IHttpActionResult CreateCustomer(customerDto CustomerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var Customer = Mapper.Map<customerDto, customer>(CustomerDto);
            _context.Customers.Add(Customer);
            _context.SaveChanges();
            CustomerDto.id = Customer.id;
            return Created(new Uri(Request.RequestUri + "/" + Customer.id), CustomerDto);
        }

        //PUT /api/customer/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, customerDto CustomerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customerDb = _context.Customers.SingleOrDefault(c => c.id == id);

            if (customerDb == null)
                return NotFound();

            Mapper.Map(CustomerDto, customerDb);

            _context.SaveChanges();
            return Ok();
        }

        //DELETE /api/customer/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerDb = _context.Customers.SingleOrDefault(c => c.id == id);
            if (customerDb == null)
                return NotFound();
            _context.Customers.Remove(customerDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
