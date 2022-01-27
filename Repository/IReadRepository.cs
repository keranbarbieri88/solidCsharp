using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solidCsharp.Repository
{
    public interface IReadRepository<T> where T : class
    {
        public IEnumerable<T> ListAll();
    
    }
}
