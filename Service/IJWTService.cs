using solidCsharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solidCsharp.Service
{
    public interface IJWTService
    {
        public string GenerateToken(User user);
    }
}
