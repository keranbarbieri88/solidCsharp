using Microsoft.IdentityModel.Tokens;
using solidCsharp.Model;
using solidCsharp.Repository;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;



namespace solidCsharp.Service
{
    public class UserService : IUserService
	{
		private IUserRepository repository;
		private ICryptographyService cryptographyService;
		private IJWTService jWTService; 

		public UserService(IUserRepository repository, ICryptographyService cryptography, IJWTService jwt)
		{
			this.repository = repository;
			this.cryptographyService = cryptography;
			this.jWTService = jwt;
		}

		public void CreateUser(string Email, string Name, string Password)
		{
			var user = this.repository.GetUser(Email);
			if (user != null)
			{
				throw new Exception("Erro, usuário já existe!");
			}
			user = new User() { Email = Email, Name = Name, Password = cryptographyService.EncryptPassword(Password)};
			this.repository.Add(user);
		}

		public string Login(string Email, string Password)
		{
			var user = this.repository.GetUser(Email);
			if (user == null || !cryptographyService.ValidatePassword(user.Password, Password))
			{
				throw new Exception("Erro, usuário ou senha incorreto!");
			}
			return jWTService.GenerateToken(user);
		}			
	}
}
