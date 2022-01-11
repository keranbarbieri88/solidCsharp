using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using solidCsharp.Model;
using solidCsharp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solidCsharp.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserService userService;

		public UserController(ILogger<UserController> logger, UserService userService)
		{
			_logger = logger;
			this.userService = userService;
		}
		[HttpPost]
		[Route("User/login")]
		public ActionResult<dynamic> Login([FromBody] User model)
		{
			// Recupera o usuário
			var token = userService.Login(model.Email, model.Password);

			// Retorna os dados
			return new
			{
				token = token
			};
		}
		[HttpPost]
		[Route("User")]
		public ActionResult<dynamic> CreateUser([FromBody] User model)
		{
			// Recupera o usuário
			userService.CreateUser(model.Email, model.Name, model.Password);

			// Retorna os dados
			return new
			{

			};
		}
	}
}
