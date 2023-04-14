using System;
using Grpc.Service;

namespace Grpc.Api.Helpers;

public static class GrpcDataGenerator
{
	public static IdentResultList ThousandData { get; }
	
	private const int ThousandIdentCount = 1000;
	private const int ComparisonCount = 15;

	static GrpcDataGenerator()
	{
		var comparison = new Comparison[ComparisonCount];
		for (var i = 0; i < ComparisonCount; i++)
		{
			comparison[i] = new Comparison
			{
				Target = Guid.NewGuid().ToString(),
				Relevance = 0.5
			};
		}

		var thousandIdentResults = new IdentResult[ThousandIdentCount];
		for (var i = 0; i < ThousandIdentCount; i++)
		{
			thousandIdentResults[i] = new IdentResult
			{
				Etalon = Guid.NewGuid().ToString(),
			};
			thousandIdentResults[i].Comparisons.AddRange(comparison);
		}
		ThousandData = new IdentResultList();
		ThousandData.IdentResults.AddRange(thousandIdentResults);
		
	}
}