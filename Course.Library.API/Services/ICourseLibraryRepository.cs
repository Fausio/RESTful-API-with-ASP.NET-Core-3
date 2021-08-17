using Course.Library.API.Entities;
using Course.Library.API.ResourceParameters;
using System;
using System.Collections.Generic;

namespace CourseLibrary.API.Services
{
    public interface ICourseLibraryRepository
    {    
        IEnumerable<Course.Library.API.Entities.Course> GetCourses(Guid authorId);
        Course.Library.API.Entities.Course GetCourse(Guid authorId, Guid courseId);
        void AddCourse(Guid authorId, Course.Library.API.Entities.Course course);
        void UpdateCourse(Course.Library.API.Entities.Course course);
        void DeleteCourse(Course.Library.API.Entities.Course course);
        IEnumerable<Author> GetAuthors(AuthorsResourceParameters authorsResourceParameters);
        Author GetAuthor(Guid authorId);
        IEnumerable<Author> GetAuthors();
        IEnumerable<Author> GetAuthors(IEnumerable<Guid> authorIds);
        void AddAuthor(Author author);
        void DeleteAuthor(Author author);
        void UpdateAuthor(Author author);
        bool AuthorExists(Guid authorId);
        bool Save();
    }
}
