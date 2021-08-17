using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Library.API.Helpers
{
    public static class DateTimeOffSetExtensions
    {
        public static int GetCurrentAge(this DateTimeOffset dateTime)
        {

            int age = DateTime.Now.Year - dateTime.Year;

            if (age < 0)
            {
                age--;
            }

            return age;
        }
    }
}
