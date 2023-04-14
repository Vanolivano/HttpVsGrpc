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
