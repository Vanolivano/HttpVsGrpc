using System.Threading.Tasks;
using Grpc.Api.Helpers;
using Grpc.Core;
using Grpc.Service;

namespace Grpc.Api.Services;

public class GrpcService : TestGrpcService.TestGrpcServiceBase
{
	public override Task<IdentResultList> GetThousand(EmptyRequest request, ServerCallContext context)
	{
		return Task.FromResult(GrpcDataGenerator.ThousandData);
	}
}