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
    public class MovieController : ApiController
    {
        private ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/product
        public IHttpActionResult GetProducts(string query = null)
        {

            var moviesQuery = _context.Products
               .Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

            var movieDtos = moviesQuery
                .ToList()
                .Select(Mapper.Map<product, MovieDto>);

            return Ok(movieDtos);
        }

        public IHttpActionResult GetProducts(int id)
        {
            var Products = _context.Products.SingleOrDefault(c => c.Id == id);
            if (Products == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(Mapper.Map<product, MovieDto>(Products));
        }
        [HttpPost]
        public IHttpActionResult CreateProducts(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var Product = Mapper.Map<MovieDto, product>(movieDto);
            _context.Products.Add(Product);
            _context.SaveChanges();
            movieDto.Id = Product.Id;
            return Created(new Uri(Request.RequestUri + "/" + Product.Id), movieDto);
        }
        [HttpPut]
        public IHttpActionResult UpdatMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var ProductDb = _context.Products.SingleOrDefault(c => c.Id == id);
            if (ProductDb == null)
                return NotFound();
            Mapper.Map(movieDto, ProductDb);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var Product = _context.Products.SingleOrDefault(c => c.Id == id);
            if (Product == null)
                return NotFound();
            _context.Products.Remove(Product);
            _context.SaveChanges();
            return Ok();
        }
    }
}
