
using Grpc.Net.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gRPCTest.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmpolyeeController : ControllerBase
	{
		GrpcChannel? channal = GrpcChannel.ForAddress("https://localhost:7037");

		[HttpGet]
		public IActionResult ResDept(int id)
		{

			//var cookie = new CookieOptions
			//{
			//	HttpOnly = true,
			//	Secure = true
			//};
			//Response.Cookies.Append("RefreshToken", "Basic ayman:ayman19", cookie);



			//var client = new EmpolyeeService
			//	var response = client.(new DeptId { Id = id });
			return Ok();
		}
	}
}
