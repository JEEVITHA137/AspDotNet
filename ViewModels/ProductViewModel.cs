using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Models;

namespace WebApplication4.ViewModels
{
    public class ProductViewModel
    {
        public List<product> product { get; set; }
        public List<customer> customer { get; set; }
        public variables variables { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public customer customer1 { get; set; }
        public product product1 { get; set; }
    }
}