using Infrastructure.Data;
using MediatR;

namespace Application.Mediator
{
	public record class GetEmpolyee(int id) : IRequest<Empolyee>;
	public class GetEmpolyeeHandler : IRequestHandler<GetEmpolyee, Empolyee>
	{
		private readonly MyDbContext _dbContext;

		public GetEmpolyeeHandler(MyDbContext dbContext)
        {
			_dbContext = dbContext;
		}

        public Task<Empolyee> Handle(GetEmpolyee request, CancellationToken cancellationToken)
		{
			return Task.FromResult(_dbContext.Empolyees.FirstOrDefault(e => e.Id == request.id)!);
		}
	}
}
