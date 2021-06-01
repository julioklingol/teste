using Application.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        private readonly ApplicationContext _db;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ApplicationContext db)
        {
            _logger = logger;
            _db = db;
        }

        
        [HttpGet]
        public Int32 Get()
        {
            var conexao = _db.Database.GetDbConnection();
            return conexao.ExecuteScalar<Int32>("select count(*) from caixas");
        }
        
    }
}
