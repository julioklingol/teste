using Aplication.Model;
using Application.Data;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Data.Repositories
{
    public class MovimentoRepository : RepositoryBase<Movimento>
    {
        public MovimentoRepository(ApplicationContext Db) : base(Db)
        {
        }

        public void CriaMovimentos(Decimal Entrada, Decimal Saida) 
        {

            using (var transaction = _db.Database.BeginTransaction())
            {
                _db.Set<Movimento>().Add(new Movimento
                {
                    Entrada = Entrada
                });

                if (Saida > 0)
                {
                    _db.Set<Movimento>().Add(new Movimento
                    {
                        Saida = Saida
                    });
                }
                _db.SaveChanges();

                transaction.Commit();
            }
        }

        public IEnumerable<Movimento> GetMovimentos()
        {
            var conexao = _db.Database.GetDbConnection();
            return conexao.Query<Movimento>("select * from movimentos");
        }

        public decimal GetSaldo()
        {
            var conexao = _db.Database.GetDbConnection();
            return conexao.ExecuteScalar<decimal>("select sum(entrada) - sum(saida) from movimentos");
        }
    }
}
