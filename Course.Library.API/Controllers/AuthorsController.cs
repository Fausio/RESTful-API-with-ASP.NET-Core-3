using AutoMapper;
using Course.Library.API.Entities;
using Course.Library.API.Helpers;
using Course.Library.API.Models;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly ICourseLibraryRepository _repository;
        private readonly IMapper _mapper;
        public AuthorsController(ICourseLibraryRepository courseLibraryRepository, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = courseLibraryRepository ?? throw new ArgumentException(nameof(courseLibraryRepository));
        }

        [HttpGet]
        public ActionResult<IEnumerable<AuthorDto>> GetAthors()
        {
            IEnumerable<Author> result = _repository.GetAuthors(); 
            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(result));
        }

        [HttpGet("{Id:guid}")]
        public ActionResult<AuthorDto> GetAthor(Guid Id)
        {
            Author result = _repository.GetAuthor(Id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AuthorDto>(result));
        }
    }
}
