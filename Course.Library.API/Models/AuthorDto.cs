using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Library.API.Models
{
    public class AuthorDto
    {
      
        public Guid Id { get; set; }
          
        public string Name { get; set; }
           
        public DateTimeOffset DateOfBirth { get; set; }
         
        public string MainCategory { get; set; }
        public int Age { get; set; }

    }
}
