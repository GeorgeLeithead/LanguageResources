namespace LanguageResources.Server.Data;

public class LanguageResourcesService
{
	/// <summary>Get language resources.</summary>
	/// <param name="language">Language.</param>
	/// <param name="ClientFactory">Client factory</param>
	/// <returns></returns>
	public async Task<IDictionary<string, string>> GetLanguageResources(string language, IHttpClientFactory ClientFactory)
	{
		var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:5001/Resources/{language}");
		request.Headers.Add("Accept", "application/json");
		request.Headers.Add("User-Agent", "LanguageResources.Server");
		var client = ClientFactory.CreateClient();
		var response = await client.SendAsync(request);
		IDictionary<string, string> items = new Dictionary<string, string>();
		if (response.IsSuccessStatusCode)
		{
			Stream stream = await response.Content.ReadAsStreamAsync();
			List<KeyValuePair<string, string>>? resources = await JsonSerializer.DeserializeAsync<List<KeyValuePair<string, string>>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
			if (resources is not null)
			{
				using (var en = resources.GetEnumerator())
				{
					while (en.MoveNext())
					{
						items.Add(en.Current);
					}
				}
			}
		}

		return items;
	}
}
