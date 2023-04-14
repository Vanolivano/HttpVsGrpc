using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace Benchmark.Starter.Configs.Columns;

public class ConstColumn : IColumn
{
	private int count;

	public string Id { get; }
	public string ColumnName { get; }

	public ConstColumn(string columnName, int count)
	{
		this.count = count;
		ColumnName = columnName;
		Id = nameof(ConstColumn) + "." + ColumnName;
	}

	public bool IsDefault(Summary summary, BenchmarkCase benchmarkCase) => false;
	//(benchmarkCase.Parameters.GetArgument("RequestCount")
	public string GetValue(Summary summary, BenchmarkCase benchmarkCase) => count.ToString();

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