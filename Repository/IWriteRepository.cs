using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solidCsharp.Repository
{
    public interface IWriteRepository<T> where T : class
    {
        public void Add(T item);
        public void Remove(T item);
        public void Update(T item);

    }
}
