namespace LanguageResources.Tests.Fixtures;

/// <summary>API Web application factory.</summary>
public class ApiWebApplicationFactory : WebApplicationFactory<Program>
{
	readonly string environment;

	/// <summary>Initialises a new instance of the <see cref="ApiWebApplicationFactory"/> class.</summary>
	/// <param name="environment">Instance environment.</param>
	public ApiWebApplicationFactory(string environment = "Development")
	{
		this.environment = environment;
	}

	/// <summary>Create application host.</summary>
	/// <param name="builder">Host builder</param>
	/// <remarks>Remove the existing application DBContextOptions and replace with the test version.</remarks>
	/// <returns>Created host.</returns>
	protected override IHost CreateHost(IHostBuilder builder)
	{
		builder.UseEnvironment(environment);
		return base.CreateHost(builder);
	}
}