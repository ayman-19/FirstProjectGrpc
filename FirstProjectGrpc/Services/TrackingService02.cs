using FirstProjectGrpc.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace FirstProjectGrpc.Services
{
	public class TrackingService02  : TrackingService.TrackingServiceBase
	{
		private readonly ILogger<TrackingService02> logger;

		public TrackingService02(ILogger<TrackingService02> logger)
		{
			this.logger = logger;
		}
		//public override Task<GetProductDto> AddProduct(AddProductDto request, ServerCallContext context)
		//{

		//	return base.AddProduct(request, context);
		//}
		public override Task<TrackingResponse> SendMassage(TrackingMassage request, ServerCallContext context)
		{
			if(request.DeviceId == 0)
				throw new RpcException(new Status(StatusCode.InvalidArgument, "Device Id Can Not Equal Zero"));
			logger.LogInformation($"{request.DeviceId} - {request.Stamp} - ({request.Location.Lat},{request.Location.Long}) - {request.Sensore.Count()}");

			return Task.FromResult(new TrackingResponse { Success = true });
		}
		public override async Task<Empty> KeepAlive(IAsyncStreamReader<PulseMessage> requestStream, ServerCallContext context)
		{
			await Task.Run(async () =>
			{
				await foreach (var message in requestStream.ReadAllAsync())
				{
					logger.LogInformation($"{message.Status} - {message.Details} - {message.Stamp}");
				}
			});
			return new Empty();
		}
		public override async Task SubscribeNotification(SubscribeRequest request, IServerStreamWriter<Notification> responseStream, ServerCallContext context)
		{
			await Task.Run(async () =>
			{
				while (!context.CancellationToken.IsCancellationRequested)
				{
					await responseStream.WriteAsync(new Notification
					{
						Stamp = Timestamp.FromDateTime(DateTime.UtcNow),
						Text = $"Device {request.DeviceId}"
					});
					await Task.Delay(4000);
					logger.LogInformation($"Device {request.DeviceId}");
				}
			});
		}
	}
}
