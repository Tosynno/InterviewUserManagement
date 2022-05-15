using Application.Dto;
using Application.Models;
using AutoMapper;
using Domain;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RoleDto, tbl_Role>().ReverseMap();
            CreateMap<RoleRequest, tbl_Role>().ReverseMap().ForMember(c => c.RoleName, opt => opt.MapFrom(c => c.Name));
            CreateMap<OnbardingRequest, tbl_User>().ReverseMap();
            CreateMap<OnboardingResponse, tbl_User>().ReverseMap();
        }
    }
}
