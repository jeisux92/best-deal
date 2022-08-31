using BestDeal.Api.Middlewares;
using BestDeal.Repository.Repositories;
using BestDeal.Repository.Repositories.Implementation;
using BestDeal.Services;
using BestDeal.Services.Implementation;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddXmlSerializerFormatters();


builder.Services.AddTransient<IAmazonRepository, AmazonRepository>();
builder.Services.AddTransient<IEbayRepository, EbayRepository>();
builder.Services.AddTransient<IMercadoLibreRepository, MercadoLibreRepository>();
builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>
        ("BasicAuthentication", null);

builder.Services.AddTransient<IAmazonService, AmazonService>();
builder.Services.AddTransient<IEbayService, EbayService>();
builder.Services.AddTransient<IMercadoLibreService, MercadoLibreService>();


var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();