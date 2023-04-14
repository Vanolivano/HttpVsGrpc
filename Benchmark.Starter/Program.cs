using System;
using System.Threading.Tasks;
using Benchmark.Starter.Services;
using BenchmarkDotNet.Running;

namespace Benchmark.Starter;

public static class Program
{
	public static void Main(string[] args)
	{
		BenchmarkRunner.Run<MyBenchmark>();
		// var httpClient = new HttpClientService();
		// var results = httpClient.GetDataAsync().GetAwaiter().GetResult();
		// var grpcClientService = new GrpcClientService();
		// var result = grpcClientService.GetDataAsync().GetAwaiter().GetResult();
		Console.ReadKey();
	}
}