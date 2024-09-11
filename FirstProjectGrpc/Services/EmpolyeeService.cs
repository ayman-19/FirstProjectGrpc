using Application.Mediator;
using FirstProjectGrpc.Protos.SharedProtos;
using Grpc.Core;
using MediatR;

namespace FirstProjectGrpc.Services
{
	public class EmpolyeeService : DeptService.DeptServiceBase
	{
		private readonly IMediator _mediator;

		public EmpolyeeService(IMediator mediator)
		{
			_mediator = mediator;
		}
		public override async Task<Emps> GetEmp(DeptId request, ServerCallContext context)
		{
			var emp = await _mediator.Send(new GetEmpolyee(request.Id));
			var response = new Emps
			{
				Id = 5,
				Name ="Ayman",
			};
			return response;
		}
	}
}
