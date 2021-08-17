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
        private readonly ICourseLibraryRepository repository;
        public AuthorsController(ICourseLibraryRepository courseLibraryRepository)
        {
            repository = courseLibraryRepository ?? throw new ArgumentException(nameof(courseLibraryRepository));
        }

        [HttpGet]
        public ActionResult<IEnumerable<AuthorDto>> GetAthors()
        {
            IEnumerable<Author> result = repository.GetAuthors();
            List<AuthorDto> authorDto = new List<AuthorDto>();

            foreach (Author autorData in result)
            {
                authorDto.Add(new AuthorDto()
                {
                    Id = autorData.Id,
                    Name = $"{autorData.FirstName} {autorData.LastName}",
                    MainCategory = autorData.MainCategory,
                    Age = autorData.DateOfBirth.GetCurrentAge(),
                    DateOfBirth = autorData.DateOfBirth.Date

                }); ;
            }

            return Ok(authorDto);
        }

        [HttpGet("{Id:guid}")]
        public IActionResult GetAthor(Guid Id)
        {
            Author result = repository.GetAuthor(Id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
