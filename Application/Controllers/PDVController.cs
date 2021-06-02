using Application.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Application.ModelView;
using Aplication.Model;
using Microsoft.Extensions.Configuration;
using Aplication.Service;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PDVController : ControllerBase
    {
        private readonly ILogger<PDVController> _logger;

        private readonly ApplicationContext _db;

        private readonly IConfiguration _configuration;

        public PDVController(ILogger<PDVController> logger, ApplicationContext db, IConfiguration configuration)
        {
            _logger = logger;
            _db = db;
            _configuration = configuration;
        }

        
        [HttpPost]
        [Route("Pagar")]
        public PDV_PagarResponseModel Pagar(PDV_PagarRequestModel request)
        {
            PDV_PagarResponseModel response = new PDV_PagarResponseModel();

            try
            {
                request.Valida(_configuration);

                Decimal troco = request.GetTroco();

                using (var transaction = _db.Database.BeginTransaction())
                {
                    _db.Set<Movimento>().Add(new Movimento
                    {
                        Entrada = request.Valor_Compra
                    });

                    if (troco > 0)
                    {
                        _db.Set<Movimento>().Add(new Movimento
                        {
                            Saida = troco
                        });
                    }
                    _db.SaveChanges();

                    transaction.Commit();
                }

                response.Ok = true;
                response.Mensagem = TrocoService.Calcular(troco).ToString();
                response.Troco = troco;

                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
            }

            return response;
        }

        [HttpGet]
        [Route("GetMovimentos")]
        public IEnumerable<Movimento> GetMovimentos()
        {
            var conexao = _db.Database.GetDbConnection();
            return conexao.Query<Movimento>("select * from movimentos");
        }

        [HttpGet]
        [Route("GetSaldo")]
        public decimal GetSaldo()
        {
            var conexao = _db.Database.GetDbConnection();
            return conexao.ExecuteScalar<decimal>("select sum(entrada) - sum(saida) from movimentos");
        }

    }
}
