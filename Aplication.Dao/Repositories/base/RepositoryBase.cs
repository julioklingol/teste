using Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplication.Data.Repositories
{
    public class RepositoryBase<T> : IDisposable, IRepositoryBase<T> where T : class
    {
        protected ApplicationContext _db;

        public RepositoryBase(ApplicationContext Db)
        {
            _db = Db;
        }
        public void Add(T obj)
        {
            _db.Set<T>().Add(obj);
            _db.SaveChanges();
        }

        public void Dispose()
        {

        }

        public IEnumerable<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public T GetById(int Id)
        {
            return _db.Set<T>().Find(Id);
        }

        public void Remove(T obj)
        {
            _db.Set<T>().Remove(obj);
            _db.SaveChanges();
        }

        public void Update(T obj)
        {
            
            _db.SaveChangesAsync();
        }
    }
}
