using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebApplication4.Models;
using WebApplication4.ViewModels;

namespace WebApplication4.Controllers
{
    public class ProductController : Controller
    {
        // GET: product
        private ApplicationDbContext _context;

        public object MembershipTypes { get; private set; }

        public ProductController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: product
        public ActionResult Random()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");
            return View("ReadOnly");
            //return Content("HELLLOOOOO!....");
            //return HttpNotFound();
            //return new EmptyResult();
            // return RedirectToAction("Index", "Home", new { page = 1, name = "jeevi" });
        }
        public ActionResult RandomCustomers()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("ListCustomers");
            return View("ReadOnlyCustomers");
        }
        public ActionResult RandomHome()
        {
            var Variable = new variables() { Name = "Jeevitha Sakthi" };
            var viewModel = new ProductViewModel
            {
                variables = Variable,
            };
            return View(viewModel);
        }
        [Route("product/Index/{value}")]
        public ActionResult Index(int value)
        {
            var Varaiable = new variables() { };
            var Product = _context.Products.ToList();
            foreach (var i in Product)
            {
                if (value == i.Id)
                {
                    Varaiable = new variables() { id = i.Id };
                }
            }
            var viewModel = new ProductViewModel
            {
                variables = Varaiable,
                product = Product
            };
            return View(viewModel);
        }
        [Route("product/IndexCustomers/{value}")]
        public ActionResult IndexCustomers(int value)
        {
            var Varaiable = new variables() { };
            var Customer = _context.Customers.Include(c => c.MembershipType).ToList();
            foreach (var i in Customer)
            {
                if (value == i.id)
                {
                    Varaiable = new variables() { Name = i.Name, id = i.MembershipTypeId };
                }
            }
            var viewModel = new ProductViewModel
            {
                variables = Varaiable,
                customer = Customer
            };
            return View(viewModel);
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var Membership = _context.MembershipTypes.ToList();
            var viewModel = new ProductViewModel
            {
                customer1 = new customer(),
                MembershipTypes = Membership
            };
            return View(viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult NewMovie()
        {
            var product = new product();
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(customer customer1)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ProductViewModel
                {
                    customer1 = customer1,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("New", viewModel);
            }

            if (customer1.id == 0)
                _context.Customers.Add(customer1);
            else
            {
                var customerDb = _context.Customers.SingleOrDefault(c => c.id == customer1.id);
                customerDb.Name = customer1.Name;
                customerDb.Birthdate = customer1.Birthdate;
                customerDb.IsSubscribedToNewsLetter = customer1.IsSubscribedToNewsLetter;
                customerDb.MembershipTypeId = customer1.MembershipTypeId;
            }
            _context.SaveChanges();
            return RedirectToAction("RandomCustomers", "product");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMovie(product product)
        {
            if (!ModelState.IsValid)
                return View("NewMovie", product);

            if (product.Id == 0)
                _context.Products.Add(product);
            else
            {
                var productDb = _context.Products.SingleOrDefault(c => c.Id == product.Id);
                productDb.Name = product.Name;
                productDb.Genre = product.Genre;
                productDb.ReleasedDate = product.ReleasedDate;
                productDb.Stock = product.Stock;
            }
            _context.SaveChanges();
            return RedirectToAction("Random", "product");
        }

        public ActionResult Edit(int id)
        {
            var Customer = _context.Customers.SingleOrDefault(c => c.id == id);
            if (Customer == null)
                return HttpNotFound();
            var viewModel = new ProductViewModel
            {
                customer1 = Customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("New", viewModel);
        }

        public ActionResult EditMovie(int id)
        {
            var Product = _context.Products.SingleOrDefault(c => c.Id == id);
            if (Product == null)
                return HttpNotFound();
            return View("NewMovie", Product);
        }
        [Route("product/order/{quantity:range(1,10)}/{price:regex(\\d{3})}")]
        public ActionResult Order(int quantity, int price)
        {
            return Content(String.Format("Quantity={0} Price={1}", quantity, price));
        }
    }
}