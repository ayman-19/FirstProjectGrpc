using FirstProjectGrpc.Protos;
using FirstProjectGrpc.Protos.SharedProtos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace GrpcClient.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TrackingMessageController : ControllerBase
	{
		GrpcChannel? channal = GrpcChannel.ForAddress("https://localhost:7037");

		//[HttpGet]
		//public IActionResult ResDept(int id)
		//{

		//	var cookie = new CookieOptions
		//	{
		//		HttpOnly = true,
		//		Secure = true
		//	};
		//	Response.Cookies.Append("RefreshToken", "Basic ayman:ayman19", cookie);



		//	var client = new EmpolyeeService
		//		var response = client.(new DeptId { Id = id });
		//	return Ok(response);
		//}
		[HttpPost]
		public async Task<IActionResult> Tracking(DtoService dto)
		{
			var client = new TrackingService.TrackingServiceClient(channal);
			try
			{
				var request = new TrackingMassage();
				request.Stamp = Timestamp.FromDateTime(dto.Date);
				request.DeviceId = dto.DeviceId;
				request.Location = new Location { Lat = 4, Long = 5 };
				request.Speed = dto.Speed;
				foreach (var item in dto.Sensors)
					request.Sensore.Add(new Sensor { Key = item.Key, Value = item.Value });
				var res = await client.SendMassageAsync(request);
				return Ok(res);
			}
			catch (RpcException ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
