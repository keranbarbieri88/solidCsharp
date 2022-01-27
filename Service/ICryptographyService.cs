using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solidCsharp.Service
{
    public interface ICryptographyService
    {
        public bool ValidatePassword(string encryptedPassword, string typedPassword);

        public string EncryptPassword(string password);
    }
}
