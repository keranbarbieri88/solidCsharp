using Microsoft.IdentityModel.Tokens;
using solidCsharp.Model;
using solidCsharp.Repository;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;



namespace solidCsharp.Service
{
    public class UserService
    {
		private UserRepository repository;
		public UserService(UserRepository repository)
		{
			this.repository = repository;
		}

		public void CreateUser(string Email, string Name, string Password)
		{
			var user = (from u in this.repository.Query() where u.Email == Email select u).FirstOrDefault();
			if (user != null)
			{
				throw new Exception("Erro, usuário já existe!");
			}
			user = new User() { Email = Email, Name = Name, Password = EncryptPassword(Password) };
			this.repository.Add(user);
		}

		public string Login(string Email, string Password)
		{
			var user = (from u in this.repository.Query() where u.Email == Email select u).FirstOrDefault();
			if (user == null || !ValidatePassword(user.Password, Password))
			{
				throw new Exception("Erro, usuário ou senha incorreto!");
			}
			return GenerateToken(user);
		}

		public string GenerateToken(User user)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(Settings.Secret);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, user.Name)
				}),
				Expires = DateTime.UtcNow.AddHours(2),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}


		public bool ValidatePassword(string encryptedPassword, string typedPassword)
		{
			byte[] hashBytes = Convert.FromBase64String(encryptedPassword);
			byte[] salt = new byte[16];
			Array.Copy(hashBytes, 0, salt, 0, 16);
			var pbkdf2 = new Rfc2898DeriveBytes(typedPassword, salt, 100000);
			byte[] hash = pbkdf2.GetBytes(20);
			for (int i = 0; i < 20; i++)
			{
				if (hashBytes[i + 16] != hash[i])
				{
					return false;
				}
			}
			return true;
		}

		public string EncryptPassword(string password)
		{
			byte[] salt;
			new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
			var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
			byte[] hash = pbkdf2.GetBytes(20);
			byte[] hashBytes = new byte[36];
			Array.Copy(salt, 0, hashBytes, 0, 16);
			Array.Copy(hash, 0, hashBytes, 16, 20);
			return Convert.ToBase64String(hashBytes);
		}
	}
}
