using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace Benchmark.Starter.Configs.Columns;

public class ResultColumn : IColumn
{
	public string Id { get; }
	public string ColumnName { get; }

	public ResultColumn(string columnName)
	{
		ColumnName = columnName;
		Id = nameof(ResultColumn) + "." + ColumnName;
		
	}

	public bool IsDefault(Summary summary, BenchmarkCase benchmarkCase) => false;
	public string GetValue(Summary summary, BenchmarkCase benchmarkCase)
	{
		var requestCount = (int)benchmarkCase.Parameters["RequestCount"];

		var resultCount = requestCount switch
		{
			400 => 10000,
			4000 => 1000,
			_ => 0
		};

		return resultCount.ToString();
	}

	public bool IsAvailable(Summary summary) => true;
	public bool AlwaysShow => true;
	public ColumnCategory Category => ColumnCategory.Custom;
	public int PriorityInCategory => 0;
	public bool IsNumeric => false;
	public UnitType UnitType => UnitType.Dimensionless;
	public string Legend => $"Custom '{ColumnName}' tag column";
	public string GetValue(Summary summary, BenchmarkCase benchmarkCase, SummaryStyle style) => GetValue(summary, benchmarkCase);
	public override string ToString() => ColumnName;
}