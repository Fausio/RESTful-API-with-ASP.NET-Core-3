using AutoMapper;
using Course.Library.API.Models;
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


        [HttpGet]
        public ActionResult<IEnumerable<CourseDto>> GetCourseForAuthor(Guid authorId)
        {
            if (!_repository.AuthorExists(authorId))
            {
                return NotFound();
            }


            IEnumerable<Entities.Course> result = _repository.GetCourses(authorId);

            if (result.Count() == 0)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<CourseDto>>(result));
        }

        [HttpGet("{courseId:guid}")]
        public ActionResult<CourseDto> GetCourseForAuthor(Guid authorId, Guid courseId)
        {
            if (!_repository.AuthorExists(authorId))
            {
                return NotFound();
            } 
             
            Entities.Course result = _repository.GetCourse(authorId, courseId);

            if (result == null)
            {
                return NotFound(); 
            }

            return Ok(_mapper.Map<CourseDto>(result));
        }

    }
}
