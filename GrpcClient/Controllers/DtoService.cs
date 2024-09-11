using System;

namespace GrpcClient.Controllers
{
	public class DtoService
	{
        public int DeviceId { get; set; }
        public int Speed{ get; set; }
        public DateTime Date { get; set; }
        public List<Sensor01> Sensors { get; set; }
	}
	public class Sensor01
	{
        public string Key { get; set; }
        public int Value { get; set; }
    }
}
