using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private IDailyNews _newsInterface;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public NewsController(IDailyNews newsService, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _newsInterface = newsService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult NewPost([FromBody] DailyNewsDto dailyNewsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("OO No ,gelen içerikler eşleşmiyor gardaş ");
            }

            var news = _mapper.Map<DailyNews>(dailyNewsDto);
            try
            {
                _newsInterface.Create(news);
                return Ok("Yazı oluşturma işlemi başarılı !");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            var news = _newsInterface.GetAll();
            var newsDtos = _mapper.Map<IList<DailyNewsDto>>(news);
            return Ok(newsDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var news = _newsInterface.GetById(id);
            var newsDtos = _mapper.Map<DailyNewsDto>(news);
            return Ok(newsDtos);
        }
        [AllowAnonymous]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]DailyNewsDto newsDto)
        {
            // map dto to entity and set id
            var news = _mapper.Map<DailyNews>(newsDto);
            news.dailyID = id;

            try
            {
                // save 
                _newsInterface.Update(news);
                return Ok("Güncelleme işlemi başarılı !");
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _newsInterface.Delete(id);
            return Ok("Silme işlemi başarılı ");
        }

    }
}