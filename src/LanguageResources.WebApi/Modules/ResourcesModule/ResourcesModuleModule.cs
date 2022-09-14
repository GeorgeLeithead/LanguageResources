namespace LanguageResources.WebApi.Modules.ResourcesModule;

using System.Collections;

/// <summary>Resources module.</summary>
public class ResourcesModuleModule : IModule
{
	/// <summary>Register a module.</summary>
	/// <param name="services">Service collection.</param>
	/// <returns>Service collection.</returns>
	public IServiceCollection RegisterModule(IServiceCollection services)
	{
		services.AddScoped<IResourcesModuleRepository, ResourcesModuleRepository>();
		return services;
	}

	/// <summary>Map endpoints.</summary>
	/// <param name="endpoints">Endpoint route builder.</param>
	/// <returns>Endpoint route builder.</returns>
	public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
	{
		endpoints.MapGet("/Resources/{language}", EndPoints.Read.HandlerByLanguage)
			.Produces<IDictionaryEnumerator?>(StatusCodes.Status200OK)
			.Produces(StatusCodes.Status404NotFound)
			.WithName("GetResourcesByLanguage")
			.WithTags("Resources")
			.AllowAnonymous();

		return endpoints;
	}
}