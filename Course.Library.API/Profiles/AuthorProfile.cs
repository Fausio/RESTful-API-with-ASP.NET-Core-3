using AutoMapper;
using Course.Library.API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Library.API.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Entities.Author, Models.AuthorDto>()
               .ForMember(
                    destine => destine.Name,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
               .ForMember(
                    destine => destine.Age,
                    opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge()));


        }
    }
}
