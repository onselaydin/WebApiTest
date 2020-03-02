using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiTest.Data;
using WebApiTest.Dtos;
using WebApiTest.Models;

namespace WebApiTest.Controllers
{
    [Produces("application/json")]
    //[Route("api/[controller]")]
    [Route("api/Cities")]
    [ApiController]
    public class CitiesController : Controller//ControllerBase
    {
        private IAppRepository _appRepository;
        private IMapper _mapper;
        public CitiesController(IAppRepository appRepository,IMapper mapper)
        {
            _appRepository = appRepository;
            _mapper = mapper;
        }
        
        public ActionResult GetCities()
        {
            var cities = _appRepository.GetCities();
            var citiesToReturn = _mapper.Map<List<CityForListDto>>(cities);
                //.Select(x=> new CityForListDto { Description=x.Description,Name=x.Name });
            return Ok(citiesToReturn);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add([FromBody]City city)
        {
            _appRepository.Add(city);
            _appRepository.SaveAll();
            return Ok(city);
        }

        [HttpGet]
        [Route("detail")]
        public ActionResult GetCityById(int Id)
        {
            var city = _appRepository.GetCityById(Id);
            var cityToReturn = _mapper.Map<CityForDetailDto>(city);
            //.Select(x=> new CityForListDto { Description=x.Description,Name=x.Name });
            return Ok(cityToReturn);
        }


    }
}