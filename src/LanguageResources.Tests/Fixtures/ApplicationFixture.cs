namespace LanguageResources.Tests.Fixtures;

using System;

/// <summary>Fixture class.</summary>
/// <remarks><see cref="https://xunit.net/docs/shared-context#class-fixture"/>Ensure that the fixture instance will be created before any of the tests have run, and once all the tests have finished, it will clean up the fixture object by calling Dispose, if present.</remarks>
public class ApplicationFixture : IDisposable
{
	bool isDisposed;

	/// <summary>Initialises a new instance of the <see cref="ApplicationFixture"/> class.</summary>
	public ApplicationFixture()
	{
		ApiWebApplicationFactory result = CreateTestApiWebApplicationFactory();
		Application = result;
	}

	public ApiWebApplicationFactory Application { get; private set; }

	/// <summary>Create test API Web Application Factory.</summary>
	/// <remarks>Ensures that:<br />
	///  - the database for the context does not exist (clean down).<br />
	///  - the database for the context exists and ensures the database schema is compatible.<br />
	///  - Seeds and saves the database.
	///  </remarks>
	/// <returns>Created factory.</returns>
	public static ApiWebApplicationFactory CreateTestApiWebApplicationFactory()
	{
		// Act
		return new ApiWebApplicationFactory("Development");
	}

	/// <inheritdoc />
	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool isDisposing)
	{
		if (isDisposed)
		{
			return;
		}

		isDisposed = true;
	}
}