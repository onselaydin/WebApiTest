using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTest.Models
{
    public class City
    {
        public City()//ctor yaz taba bas...
        {
            Photos = new List<Photo>();
        }

        public int Id { get; set; } //prop yaz taba bas...
        public string Description { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }

        //bire çok ilişki yani şehrin fotoğrafları....
        public List<Photo> Photos { get; set; }
        public User User { get; set; }

    }
}
