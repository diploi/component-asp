using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<HostOptions>(options =>
{
    options.ShutdownTimeout = TimeSpan.FromSeconds(1);
});

// Configure Kestrel to allow port reuse and SO_REUSEADDR
builder.WebHost.ConfigureKestrel((context, options) =>
{
    options.ListenAnyIP(5103, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
    });
});


builder.Services.AddControllers();

// Configure data protection 
builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo("/var/dpkeys"));

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseForwardedHeaders();

app.UseAuthorization();

app.MapControllers();


app.Run();


