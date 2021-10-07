using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OpenDataWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;



namespace OpenDataWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopulationController : ControllerBase
    {
        private readonly PopulationRepository _PopulationRepository;
        private IConfiguration configuration;
        public PopulationController(IConfiguration config)
        {
            configuration = config;
            this._PopulationRepository = new PopulationRepository();
        }
        // 取得API資料返回畫面
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var PopulationCount = await _PopulationRepository.GetPopulationDataFromOpenDataApi();
                return Ok(PopulationCount);
            }
            catch(HttpRequestException ex)
            {
                return Problem(ex.Message);
            }
           
        }
        /// <summary>
        /// 寫入DB
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Insert()
        {
            try
            {
                var PopulationCount = await _PopulationRepository.GetPopulationDataFromOpenDataApi();
                var dbconn = configuration.GetSection("ConnectionStrings").GetSection("DBConnection").Value;
                if (string.IsNullOrEmpty(dbconn))
                    throw new Exception("Need Db Connect Information");
                using var connection = new SqlConnection(dbconn);
                foreach( var item in PopulationCount.responseData)
                { 
                 _PopulationRepository.Create(connection, item);
                }
                return Ok();
            }
            catch (HttpRequestException ex)
            {
                return Problem(ex.Message);
            }
          
        }

    }
}
