using AutoMapper;
using Course.Library.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Library.API.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Entities.Course, CourseDto>(); 
        }
    }
}
