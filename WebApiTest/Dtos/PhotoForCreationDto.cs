using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTest.Dtos
{
    public class PhotoForCreationDto
    {
        //bu bir constraction dır. class ismi ile
        // metod ismi aynı bu class çağrılınca bu
        //çalışacaktır
        public PhotoForCreationDto()
        {
            DateAdded = DateTime.Now;
        }
        public string Url { get; set; }
        public IFormFile File { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public string PublicId { get; set; }
    }
}
