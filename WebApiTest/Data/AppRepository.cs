using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest.Models;

namespace WebApiTest.Data
{
    public class AppRepository : IAppRepository // sağ click implement all yaptık.
    {
        private DataContext _context;
        public AppRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public List<City> GetCities()
        {
            //şehirleri fotoğraflarıyla getirecek. Modelde yapmıştık.
            var cities = _context.Cities.Include(p=>p.Photos).ToList();
            return cities;
        }

        public City GetCityById(int cityId)
        {
            var city = _context.Cities.Include(c => c.Photos).FirstOrDefault(c => c.Id == cityId);
            return city;
        }

        public Photo GetPhoto(int id)
        {
            var photo = _context.Photos.FirstOrDefault(p => p.Id == id);
            return photo;
            //throw new NotImplementedException();
        }

        public List<Photo> GetPhotosByCity(int id)
        {
            var photos = _context.Photos.Where(p => p.CityId == id).ToList();
            return photos;
        }

        //public bool SaveAll()
        //{
        //    return _context.SaveChanges() > 0;
        //}

        void IAppRepository.SaveAll()
        {
            _context.SaveChanges();
        }
    }
}
