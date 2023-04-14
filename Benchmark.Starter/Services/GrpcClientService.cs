using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Grpc.Service;

namespace Benchmark.Starter.Services;

public class GrpcClientService
{
	private const string Address = "http://127.0.0.1:5273";
	private static readonly HttpClientHandler HttpHandler = new()
	{
		ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
	};

	private static readonly GrpcChannel Channel =
		GrpcChannel.ForAddress(Address, new GrpcChannelOptions
		{
			HttpHandler = HttpHandler,
			MaxReceiveMessageSize = null
		});

	private static readonly TestGrpcService.TestGrpcServiceClient Client = new(Channel);

	public async Task<IdentResultList> GetDataAsync()
	{
		return await Client.GetThousandAsync(new EmptyRequest());
	}
}