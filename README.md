<img alt="icon" src=".diploi/icon.svg" width="32">

# ASP.NET Component for Diploi

[![launch with diploi badge](https://diploi.com/launch.svg)](https://diploi.com/component/asp)
[![component on diploi badge](https://diploi.com/component.svg)](https://diploi.com/component/asp)
[![latest tag badge](https://badgen.net/github/tag/diploi/component-asp)](https://diploi.com/component/asp)

## Operation

### Getting started

1. In the Dashboard, click **Create Project +**
2. Under **Pick Components**, choose **ASP.NET**. Here you can also add a frontend framework to create a monorepo app
3. In **Pick Add-ons**, you can add one or multiple databases to your app
4. Choose **Create Repository** to generate a new GitHub repo
5. Finally, click **Launch Stack**

Link to the full guide - upcoming

### Development

During development, the container uses `dotnet watch` to enable automatic reloads when files change. The development server is started with:

```sh
dotnet watch run --no-launch-profile --hot-reload --non-interactive
```
This will:
- Use `dotnet watch` to monitor for changes to C# source files and restart the server when changes are detected.
- Run the ASP.NET application with hot reload enabled.
- Start the app on port 5103.
- Avoid using any launch profile so environment variables are controlled by the container.

### Installing Packages

**NuGet packages** (C# libraries and frameworks):
```sh
dotnet add package <PackageName>
```
For example:
```sh
dotnet add package Newtonsoft.Json
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

The `.csproj` file tracks NuGet dependencies, triggering automatically restored during development and build.

### Production
 
Builds a production-ready image. During the build, dependencies are restored with `dotnet restore` and the application is published with `dotnet publish`. When the container starts, it runs:

```sh
dotnet component-asp.dll
```

This uses the compiled .NET application optimized for production deployment.

### Data Protection

The application uses ASP.NET Core Data Protection for securing authentication cookies and anti-forgery tokens. In Kubernetes deployments, data protection keys are persisted using a PersistentVolumeClaim to ensure session continuity across pod restarts.

## Links

- [ASP.NET Core documentation](https://docs.microsoft.com/en-us/aspnet/core/)
- [.NET documentation](https://docs.microsoft.com/en-us/dotnet/)
