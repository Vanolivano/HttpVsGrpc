using Http.Dto;
using Http.Api.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Http.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class HttpController : ControllerBase
{
	[HttpGet(Name = nameof(GetThousandDataAsync))]
	public Task<IdentResult[]> GetThousandDataAsync()
	{
		return Task.FromResult(HttpDataGenerator.ThousandData);
	}

	[HttpGet(Name = nameof(GetDataStreamAsync))]
	public IAsyncEnumerable<IdentResult> GetDataStreamAsync()
	{
		return Stream();


		async IAsyncEnumerable<IdentResult> Stream()
		{
			foreach (var data in HttpDataGenerator.ThousandData)
			{
				var weatherForecast = await Task.FromResult(data);

				yield return weatherForecast;
			}
		}
	}
}