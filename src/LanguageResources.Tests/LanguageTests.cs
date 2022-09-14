namespace LanguageResources.Tests;

using System.Collections.Generic;
using System.Text.Json;

[Collection("Context Collection")]
public class LanguageTests
{
	readonly ApplicationFixture appFixture;

	/// <summary>Initialises a new instance of the <see cref="LanguageTests"/> class.</summary>
	/// <param name="fixture">Class fixture.</param>
	public LanguageTests(ApplicationFixture fixture)
	{
		appFixture = fixture;
	}

	[Theory]
	[InlineData("Hello", "Hello", "en-GB")]
	[InlineData("Goodbye", "Goodbye", "en-GB")]
	[InlineData("WhereIsThe", "Where is the", "en-GB")]
	[InlineData("Hello", "Bonjour", "fr-FR")]
	[InlineData("Goodbye", "Au Revoir", "fr-FR")]
	[InlineData("WhereIsThe", "Où est le", "fr-FR")]
	[InlineData("Goodbye", "وداعًا", "ar-DZ")]
	[InlineData("Hello", "مرحبًا", "ar-DZ")]
	[InlineData("WhereIsThe", "أين هو", "ar-DZ")]
	public async Task GetResourceLanguage(string keyName, string keyValue, string language)
	{
		// Act
		HttpClient client = appFixture.Application.CreateClient();
		HttpResponseMessage response = await client.GetAsync($"/Resources/{language}");
		Stream stream = await response.Content.ReadAsStreamAsync();

		// Assert
		Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		List<KeyValuePair<string, string>>? resources = await JsonSerializer.DeserializeAsync<List<KeyValuePair<string, string>>>(stream, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
		Assert.NotNull(resources);
		IDictionary<string, string> items = new Dictionary<string, string>();
		foreach (KeyValuePair<string, string> item in resources)
		{
			items.Add(item);
		}

		Assert.True(items.ContainsKey(keyName));
		Assert.True(items[keyName].Equals(keyValue));
	}
}