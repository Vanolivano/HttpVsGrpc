using System.Threading.Tasks;
using Benchmark.Starter.Configs;
using Benchmark.Starter.Services;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.InProcess.NoEmit;

namespace Benchmark.Starter;

[Config(typeof(MyConfig))]
public class MyBenchmark
{
	[Params(4000)]
	public int RequestCount;

	private readonly HttpClientService _httpClientService = new();
	private readonly GrpcClientService _grpcClientService = new();

	[Benchmark(Description = nameof(GetHttpDataAsync))]
	public async Task GetHttpDataAsync()
	{
		for (var i = 0; i < RequestCount; i++)
		{
			await _httpClientService.GetDataAsync();
		}
	}
	
	[Benchmark(Description = nameof(GetGrpcDataAsync))]
	public async Task GetGrpcDataAsync()
	{
		for (var i = 0; i < RequestCount; i++)
		{
			await _grpcClientService.GetDataAsync();
		}
	}

	// [Benchmark(Description = nameof(GetStreamData))]
	// public async Task GetStreamData()
	// {
	// 	var results = _httpClientService.GetStreamDataAsync();
	//
	// 	await foreach (var _ in results)
	// 	{
	// 		
	// 	}
	// }
}