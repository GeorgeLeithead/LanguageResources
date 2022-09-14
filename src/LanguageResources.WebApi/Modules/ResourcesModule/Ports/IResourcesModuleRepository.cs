namespace LanguageResources.WebApi.Modules.ResourcesModule.Ports;
/// <summary>Resources repository.</summary>
public interface IResourcesModuleRepository
{
	/// <summary>GET/Read Resources.</summary>
	/// <param name="language">Language.</param>
	/// <returns>Resource set.</returns>
	ResourceSet? ReadByLanguage(string language);
}