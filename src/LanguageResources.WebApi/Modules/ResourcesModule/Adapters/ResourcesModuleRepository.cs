namespace LanguageResources.WebApi.Modules.ResourcesModule.Adapters;
/// <summary>Resources module repository.</summary>
public class ResourcesModuleRepository : IResourcesModuleRepository
{
	/// <summary>Initialises a new instance of the <see cref="ResourcesModuleRepository"/> class.</summary>
	public ResourcesModuleRepository()
	{ }

	/// <summary>GET/Read Resources.</summary>
	/// <param name="language">Language.</param>
	/// <returns>Resource set.</returns>
	public ResourceSet? ReadByLanguage(string language)
	{
		ResourceManager resourceManager = new("LanguageResources.Shared.Resources.Resource", typeof(Resource).Assembly);
		CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture(language);
		return resourceManager.GetResourceSet(cultureInfo, true, true);
	}
}
