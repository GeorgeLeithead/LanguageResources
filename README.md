# LanguageResources
A Web API and simple Blazor WASM app to demonstrate getting different language resources and using within JavaScript.

This repository shows how to use the .NET 6 minimal Web API which implements the 'domain/module-driven' approach. It moves from the traditional folder structure where the application is grouped by its domain.  The different domains of the application are organised in module (or feature) folders.

## The structure of a module
The benefits of this approach makes that every module becomes self-contained.  Simple modules can have a simple set-up, while a module has the flexibility to deviate from the "default" set-up for more complex modules.  A domain-based structure groups files and folders by their (sub)domain, this gives us a better understanding of the application and makes it easier to navigate through the application.

## Minimal API
Using the .NET 6 minimal API framework. See [Minimal APIs overview](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-6.0) for details.

## Testing

### Web API
We will be using XUnit for integration testing.

#### InternalsVisibleTo
To make the API project visible to internal testing, we need to add the following to the API project:
```xml
<ItemGroup>
	<InternalsVisibleTo Include="LanguageResources.Tests" />
</ItemGroup>
```
Add to the API Program.cs the following to make the implicit Program class public so test projects can access it.
```csharp
public partial class Program { }
```

#### Using HTTPREPL
 1. Run the following .NET Core CLI command in the command shell:
```bash
dotnet run
```
The preceding command locates the project at the current directory, retrieves and installs any required project dependencies, compiles the project code, and hosts the web API with the ASP.NET Code Kestrel web server at both an HTTP and HTTPS endpoint.

Ports as defined in the project will be selected for HTTP, port 5000, and port 5001 for HTTPS. Ports used during development can be easily changed by editing the project's launchSettings.json file.

A variation of the following output appears to indicate that the app is running:

```cmd
Building...
info: LanguageResources.WebApi[0]
	  Starting LanguageResources 09/15/2022 07:33:30
info: Microsoft.Hosting.Lifetime[14]
	  Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[14]
	  Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
	  Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
	  Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
	  Content root path: ..\src\LanguageResources.WebApi\
```
2. Open a new integrated terminal, then run the following command to install the .NET HTTP REPL command-line tool, to use to make HTTP requests to the web API:
```cmd
dotnet tool install -g Microsoft.dotnet-httprepl
```
3. Connect to the web API by running the following command:
```cmd
httprepl https://localhost:5001
```
This will produce output like the following:
```cmd
(Disconnected)> connect https://localhost:5001
Using a base address of https://localhost:5001/
Using OpenAPI description at https://localhost:5001/swagger/v1/swagger.json
For detailed tool info, see https://aka.ms/http-repl-doc
```

4. Explore the available endpoints by running the following command:
```cmd
ls
```
The preceding command detects all APIs available on the connected endpoint.  A variation of the following output appears:
```cmd
https://localhost:5001/> ls
.           []
Resources   []
```
5. Go to the **Resources** endpoint by running the following command:
```cmd
cd Resources
```
6. make a **GET** request in **HttpRepl** by using the following command, specifying the resource language required:
```cmd
get fr-FR
```
The preceding command makes a **GET** request:
```json
HTTP/1.1 200 OK
Content-Type: application/json; charset=utf-8
Date: Thu, 15 Sep 2022 07:36:47 GMT
Server: Kestrel
Transfer-Encoding: chunked

[
  {
	"key": "Goodbye",
	"value": "Au Revoir"
  },
  {
	"key": "Hello",
	"value": "Bonjour"
  },
  {
	"key": "WhereIsThe",
	"value": "Où est le"
  }
]
```
7. To exit the shell, run the following command
```cmd
Exit
```

#### Logger
The application includes logging via Dependency Injection (DI).  Requests to the API end-points include logging to the targets as defined by the `appsettings.json` file.  In debug this can produce the following:
```cmd
info: Microsoft.Hosting.Lifetime[0]
	  Content root path: ..\LanguageResources\src\LanguageResources.WebApi\
info: Program[0]
	  [Modules.ResourcesModule.Read.HandlerByLanguage] Request resources for language:=en-GB @09/15/2022 07:36:25 +00:00
info: Program[0]
	  [Modules.ResourcesModule.Read.HandlerByLanguage] Read resources for language:=en-GB @09/15/2022 07:36:25 +00:00
info: Program[0]
	  [Modules.ResourcesModule.Read.HandlerByLanguage] Request resources for language:=fr-FR @09/15/2022 07:36:48 +00:00
info: Program[0]
	  [Modules.ResourcesModule.Read.HandlerByLanguage] Read resources for language:=fr-FR @09/15/2022 07:36:48 +00:00
```

### Blazor Server
The blazor server app requires that the Web API is running.

#### Running the Web API
Run the following .NET Core CLI command in the command shell, from the `LanguageResources.WebApi` project folder:
```bash
dotnet run
```
The preceding command locates the project at the current directory, retrieves and installs any required project dependencies, compiles the project code, and hosts the web API with the ASP.NET Code Kestrel web server at both an HTTP and HTTPS endpoint.

Ports as defined in the project will be selected for HTTP, port 5000, and port 5001 for HTTPS. Ports used during development can be easily changed by editing the project's launchSettings.json file.

A variation of the following output appears to indicate that the app is running:

```cmd
Building...
info: LanguageResources.WebApi[0]
	  Starting LanguageResources 09/15/2022 07:33:30
info: Microsoft.Hosting.Lifetime[14]
	  Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[14]
	  Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
	  Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
	  Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
	  Content root path: ..\src\LanguageResources.WebApi\
```

### Stopping the Web API
When finished with the Web API, in the .NET Core CLI command shell, press `CTRL+C`.