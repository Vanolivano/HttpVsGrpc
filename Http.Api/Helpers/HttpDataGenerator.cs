using Http.Dto;

namespace Http.Api.Helpers;

public static class HttpDataGenerator
{
	public static IdentResult[] ThousandData { get; }
	
	static HttpDataGenerator()
	{
		var comparison = new Comparison[ComparisonCount];
		for (var i = 0; i < ComparisonCount; i++)
		{
			comparison[i] = new Comparison(Guid.NewGuid().ToString(), 0.5);
		}

		ThousandData = new IdentResult[ThousandIdentCount];
		for (var i = 0; i < ThousandIdentCount; i++)
		{
			ThousandData[i] = new IdentResult(Guid.NewGuid().ToString(), comparison);
		}
	}

	private const int ThousandIdentCount = 1000;
	private const int ComparisonCount = 15;
}