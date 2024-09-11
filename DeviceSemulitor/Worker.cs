using FirstProjectGrpc.Protos;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;

namespace DeviceSemulitor
{
	public class Worker : BackgroundService
	{
		private readonly ILogger<Worker> _logger;
		private readonly int deviceId;

		public Worker(ILogger<Worker> logger,int deviceId)
		{
			_logger = logger;
			this.deviceId = deviceId;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			while (!stoppingToken.IsCancellationRequested)
			{
				var random = new Random();
				var client = new TrackingService.TrackingServiceClient(GrpcChannel.ForAddress(" https://localhost:7037"));
				var request = new TrackingMassage
				{
					DeviceId = deviceId,
					Location = { Lat = random.Next(1, 100), Long = random.Next(1, 100) },
					Speed = random.Next(1, 220),
					Stamp = Timestamp.FromDateTime(DateTime.UtcNow),

				};
				request.Sensore.Add(new Sensor { Key = "A", Value = 1 });
				request.Sensore.Add(new Sensor { Key = "B", Value = 2 });
				var response= await client.SendMassageAsync(request);
				_logger.LogInformation($"Response #{response.Success}");
				await Task.Delay(1000, stoppingToken);
			}
		}
	}
}
