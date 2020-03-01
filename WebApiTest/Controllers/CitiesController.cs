using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTest.Data;
using WebApiTest.Dtos;

namespace WebApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private IAppRepository _appRepository;
        public CitiesController(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }
        
        public ActionResult GetCities()
        {
            var cities = _appRepository.GetCities()
                .Select(x=> new CityForListDto { Description=x.Description,Name=x.Name });
            return Ok(cities);
        }



    }
}