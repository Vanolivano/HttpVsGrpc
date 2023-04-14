# HttpVsGrpc
Research work, comparison of data transfer rates via grpc and via http (http/2 + Message Pack)
## Composition of the solution
* `Benchmark.Starter:` implements clients, runs test.
* `Grpc.Api:` grpc api server.
```
public override Task<IdentResultList> GetThousand(EmptyRequest request, ServerCallContext context)
{
   return Task.FromResult(GrpcDataGenerator.ThousandData);
}
```
* `Grpc.Protos:` grpc protos.
* `Http.Api:` http api server; only http/2; message pack serialization;
```
public Task<IdentResult[]> GetThousandDataAsync()
{
   return Task.FromResult(HttpDataGenerator.ThousandData);
}
```
* `Http.Dto:` http models.
## Purpose
To compare data transfer rate via grpc and http.
## Data
```
public record Comparison(string Target, double Relevance);
public record IdentResult(string Etalon, Comparison[] Comparisons);
```
## Benchmark
4000 requests, 1000 results, 15 comparisions.
### Results
``` ini
BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19044.2728/21H2/November2021Update)
11th Gen Intel Core i7-1165G7 2.80GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.202
  [Host] : .NET 7.0.4 (7.0.423.11508), X64 RyuJIT AVX2

Toolchain=InProcessNoEmitToolchain  IterationCount=1  LaunchCount=1  
WarmupCount=1  
```
|           Method | RequestCount |    Mean | Error | Result count | Comparison count |
|----------------- |------------- |--------:|------:|------------- |----------------- |
| GetHttpDataAsync |         4000 | 29.09 s |    NA |         1000 |               15 |
| GetGrpcDataAsync |         4000 | 23.91 s |    NA |         1000 |               15 |
