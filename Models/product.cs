using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebApplication4.Models
{
    public class product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        [Display(Name = "Released Date")]
        public string ReleasedDate { get; set; }
        [Required]
        [StockBtwn]
        public int Stock { get; set; }
        public byte NumberAvailable { get; set; }
    }
}