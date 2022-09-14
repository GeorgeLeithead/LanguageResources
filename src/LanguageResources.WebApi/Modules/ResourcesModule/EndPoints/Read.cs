namespace LanguageResources.WebApi.Modules.ResourcesModule.EndPoints;
/// <summary>Read discussions endpoint.</summary>
public static class Read
{
	/// <summary>GET/Read resources by language.</summary>
	/// <param name="language">Language.</param>
	/// <param name="resourcesModuleRepository">Resources Repository.</param>
	/// <param name="logger">Logger.</param>
	/// <returns>Status 200 Ok.</returns>
	/// <returns>Status 404 Not Found.</returns>
	public static IResult HandlerByLanguage(string language, IResourcesModuleRepository resourcesModuleRepository, ILogger logger)
	{
		logger.LogInformation("[Modules.ResourcesModule.Read.HandlerByLanguage] Request resources for language:={language} @{LogTime}", language, DateTimeOffset.UtcNow);
		ResourceSet? resources = resourcesModuleRepository.ReadByLanguage(language);
		if (resources == null)
		{
			logger.LogError("[Modules.ResourcesModule.Read.HandlerByLanguage] Resources not found for language:={language} @{LogTime}", language, DateTimeOffset.UtcNow);
			return Results.NotFound();
		}

		logger.LogInformation("[Modules.ResourcesModule.Read.HandlerByLanguage] Read resources for language:={language} @{LogTime}", language, DateTimeOffset.UtcNow);
		return Results.Ok(resources);
	}

}