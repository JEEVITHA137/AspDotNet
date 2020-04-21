using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Dtos;
using WebApplication4.Models;

namespace WebApplication4.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<customer, customerDto>();
            Mapper.CreateMap<product, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipDto>();

            Mapper.CreateMap<customerDto, customer>()
                .ForMember(c => c.id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDto, product>()
                 .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}