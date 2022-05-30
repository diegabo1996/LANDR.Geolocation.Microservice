using LANDR.Geolocation.Microservice.Behaviors;
using LANDR.Geolocation.Microservice.GeoIP.Manager;
using LANDR.Geolocation.Microservice.ModelHelpers;
using MaxMind.GeoIP2;
using Microsoft.AspNetCore.HttpOverrides;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Configuration.AddJsonFile(AppDomain.CurrentDomain.BaseDirectory + "appsettings.json",
            optional: false,
            reloadOnChange: true).
    AddEnvironmentVariables().Build();
builder.Services.Configure<WebServiceClientOptions>(builder.Configuration.GetSection("MaxMind"));
builder.Services.Configure<ConfigurationMicroservice>(builder.Configuration.GetSection("ConfigurationMicroservice"));
builder.Services.AddHttpClient<WebServiceClient>();
builder.Services.AddSingleton<DatabaseReader>(new DatabaseReader(AppDomain.CurrentDomain.BaseDirectory + @"LocalDataBase/City.mmdb"));
builder.Services.AddTransient<QueryOnline>();
builder.Services.AddTransient<QueryLocal>();
builder.Services.AddTransient<SwitchOnlineLocal>(switchOL => key =>
{
    switch (key)
    {
        case true:
            return switchOL.GetService<QueryOnline>();
        case false:
            return switchOL.GetService<QueryLocal>();
    }
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
