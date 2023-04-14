using Benchmark.Starter.Configs.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.InProcess.NoEmit;

namespace Benchmark.Starter.Configs;

public class MyConfig : ManualConfig
{
	public MyConfig()
	{
		var job = new Job { Run = { LaunchCount = 1, WarmupCount = 1, IterationCount = 1}}
			.WithToolchain(InProcessNoEmitToolchain.Instance);
		AddJob(job);
		AddColumn(new ConstColumn("Result count", 1000));
		AddColumn(new ConstColumn("Comparison count", 15));
	}
}