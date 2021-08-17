using Course.Library.API.Entities;
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
        private readonly ICourseLibraryRepository repository;
        public AuthorsController(ICourseLibraryRepository courseLibraryRepository)
        {
            repository = courseLibraryRepository ?? throw new ArgumentException(nameof(courseLibraryRepository));
        }

        [HttpGet]
        public IActionResult GetAthors()
        {
            var result = repository.GetAuthors(); 
            return Ok(result);
        }

        [HttpGet("{Id:guid}")]
        public IActionResult GetAthor(Guid Id)
        {
            Author result = repository.GetAuthor(Id);

            if (result == null)
            {
                return NotFound();
            }
            
            return   Ok(result);
        }
    }
}
