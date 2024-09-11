
using FirstProjectGrpc.Services;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authentication;
using System.Reflection;

namespace FirstProjectGrpc
{
    public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
			builder.Services.AddDbContext<MyDbContext>();
			// Add services to the container.
			builder.Services.AddGrpc();
			builder.Services.AddGrpcReflection();
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.MapGrpcReflectionService();
			}
			
			app.MapGrpcService<TrackingService02>();
			app.MapGrpcService<EmpolyeeService>();
			app.Run();
		}
	}
}