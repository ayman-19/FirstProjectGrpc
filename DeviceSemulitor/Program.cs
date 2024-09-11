namespace DeviceSemulitor
{
	public class Program
	{
		public static void Main(string[] args)
		{
            Console.WriteLine("Enter Device Id : ");
			int deviceId = Convert.ToInt32(Console.ReadLine());
            var builder = Host.CreateApplicationBuilder(args);
			builder.Services.AddHostedService<Worker>(p =>
			{
				var logger = p.GetService<ILogger<Worker>>();
				return new Worker(logger!, deviceId);
			});

			var host = builder.Build();
			host.Run();
		}
	}
}