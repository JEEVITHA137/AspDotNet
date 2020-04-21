using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication4.Models;

namespace WebApplication4.Dtos
{
    public class customerDto
    {
        public int id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public MembershipDto MembershipType { get; set; }
        //[Min18IfAMember]
        public DateTime? Birthdate { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public byte MembershipTypeId { get; set; }
    }
}