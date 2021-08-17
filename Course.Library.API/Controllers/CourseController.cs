using AutoMapper;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Library.API.Controllers
{
    [Route("api/authors/{authorId}/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseLibraryRepository _repository;
        private readonly IMapper _mapper;
        public CourseController(ICourseLibraryRepository courseLibraryRepository, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = courseLibraryRepository ?? throw new ArgumentException(nameof(courseLibraryRepository));
        }


    }
}
