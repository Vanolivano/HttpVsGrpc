using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Http.Dto;
using MessagePack;
using MessagePack.Resolvers;

namespace Benchmark.Starter.Services;

public class HttpClientService
{
	private const string RequestUri = "http://127.0.0.1:5271/Http/GetThousandData";

	private static readonly HttpClient Client = new()
	{
		DefaultRequestVersion = HttpVersion.Version20,
		DefaultVersionPolicy = HttpVersionPolicy.RequestVersionExact
	};

	public HttpClientService()
	{
		Client.DefaultRequestHeaders.Accept.Clear();
		Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-msgpack"));
	}

	public async Task<IdentResult[]> GetDataAsync()
	{
		return MessagePackSerializer.Deserialize<IdentResult[]>(
			await Client.GetByteArrayAsync(RequestUri),
			new MessagePackSerializerOptions(ContractlessStandardResolver.Instance));
	}

	public async IAsyncEnumerable<IdentResult> GetStreamDataAsync()
	{
		var responseMessage = await Client.GetAsync(
			RequestUri,
			HttpCompletionOption.ResponseHeadersRead);

		responseMessage.EnsureSuccessStatusCode();

		var responseStream = await responseMessage.Content.ReadAsStreamAsync();

		var asyncResults = JsonSerializer.DeserializeAsyncEnumerable<IdentResult>(
			responseStream,
			new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true,
				DefaultBufferSize = 128
			});

		await foreach (var result in asyncResults)
		{
			yield return result;
		}
	}
}