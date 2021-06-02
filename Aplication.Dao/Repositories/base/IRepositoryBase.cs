using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Data.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T obj);

        T GetById(int Id);

        IEnumerable<T> GetAll();

        void Update(T obj);
        void Remove(T obj);
        void Dispose();
    }
}
