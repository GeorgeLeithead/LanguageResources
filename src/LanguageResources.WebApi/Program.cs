using LanguageResources.WebApi.Modules;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.RegisterModules();
builder.Services.AddScoped<ILogger, Logger<Program>>();

builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "LanguageResources", Version = "v1" });
	string? docFilePath = Path.Combine(AppContext.BaseDirectory, "LanguageResources.WebApi.xml");
	c.IncludeXmlComments(docFilePath);
});

WebApplication app = builder.Build();

app.UseSwagger();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapSwagger();
	app.UseSwagger();
	app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
}

app.UseHttpsRedirection();
app.MapControllers();
app.MapEndpoints();
app.UseRouting();
app.UseAuthorization();

app.Logger.LogInformation("Starting LanguageResources {date}", DateTime.UtcNow);
app.Run();

/// <summary>Program class.</summary>
/// <remarks>Make the implicit Program class public so test projects can access it.</remarks>
public partial class Program { }