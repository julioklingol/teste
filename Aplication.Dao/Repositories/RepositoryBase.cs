using Aplication.Data.Repositories;
using Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Dao.Repositories
{
    public class RepositoryBase<T> : IDisposable, IRepositoryBase<T> where T : class
    {
        protected AppicationContext Db = new AppicationContext();
        public void Add(T obj)
        {
            Db.Set<T>().Add(obj);
            Db.SaveChanges();
        }

        public void Dispose()
        {

        }

        public IEnumerable<T> GetAll()
        {
            return Db.Set<T>().ToList();
        }

        public T GetById(int Id)
        {
            return Db.Set<T>().Find(Id);
        }

        public void Remove(T obj)
        {
            Db.Set<T>().Remove(obj);
            Db.SaveChanges();
        }

        public void Update(T obj)
        {
            //Db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            Db.SaveChangesAsync();
        }
    }
}
