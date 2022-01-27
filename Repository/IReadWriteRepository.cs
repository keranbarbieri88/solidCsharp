using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solidCsharp.Repository
{
    public interface IReadWriteRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class
    {

    }
}
