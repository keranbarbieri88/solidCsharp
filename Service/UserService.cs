using Microsoft.IdentityModel.Tokens;
using solidCsharp.Model;
using solidCsharp.Repository;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;



namespace solidCsharp.Service
{
    public class UserService
    {
		private IUserRepository repository;
		public UserService(IUserRepository repository)
		{
			this.repository = repository;
		}

		public void CreateUser(string Email, string Name, string Password)
		{
			var user = this.repository.GetUser(Email);
			if (user != null)
			{
				throw new Exception("Erro, usuário já existe!");
			}
			user = new User() { Email = Email, Name = Name, Password = new CryptographyService().EncryptPassword(Password)};
			this.repository.Add(user);
		}

		public string Login(string Email, string Password)
		{
			var user = this.repository.GetUser(Email);
			if (user == null || !new CryptographyService().ValidatePassword(user.Password, Password))
			{
				throw new Exception("Erro, usuário ou senha incorreto!");
			}
			return new JWTService().GenerateToken(user);
		}			
	}
}
