using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.ModelView
{
    public class RequestBase
    {
        public String Token { get; set; }

        public virtual void Valida(IConfiguration configuration)
        {
            if (Token != configuration["Token"])
            {
                throw new Exception("Token inválido informe 1234");
            }
        }
    }
}
