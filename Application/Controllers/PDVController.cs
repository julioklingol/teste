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
using Aplication.Data.Repositories;

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

        /// <summary>
        /// Api para efetuar o pagamento da compra
        ///     Faz o registro do pagamento em banco de dados e retorna o troco devido
        /// </summary>
        /// <param name="request">Objeto Json com Valor da Compra, Valor Pago e Token de Acesso para Seguraça.
        /// Informe para teste 1234
        /// </param>
        /// <returns>Retorna objeto com dados do troco</returns>
        [HttpPost]
        [Route("Pagar")]
        public PDV_PagarResponseModel Pagar(PDV_PagarRequestModel request)
        {
            PDV_PagarResponseModel response = new PDV_PagarResponseModel();

            try
            {
                request.Valida(_configuration);

                //Faz o calculo do troco no prórpio objeto de request
                Decimal troco = request.GetTroco();

                using (var repository = new MovimentoRepository(_db))
                {
                    repository.CriaMovimentos(request.Valor_Pago, troco);
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

        /// <summary>
        /// Retorno os movimentos de entrada e saida realizados utilizando Dapper
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetMovimentos")]
        public IEnumerable<Movimento> GetMovimentos()
        {
            using (var repository = new MovimentoRepository(_db))
            {
                return repository.GetMovimentos();
            }
        }

        /// <summary>
        /// Retorna o total do saldo atual utilizando Dapper
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetSaldo")]
        public decimal GetSaldo()
        {
            using (var repository = new MovimentoRepository(_db))
            {
                return repository.GetSaldo();
            }
        }

    }
}
