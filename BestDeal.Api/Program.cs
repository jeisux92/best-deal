using BestDeal.Repository.Repositories;
using BestDeal.Repository.Repositories.Implementation;
using BestDeal.Services;
using BestDeal.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddXmlSerializerFormatters();


builder.Services.AddTransient<IAmazonRepository, AmazonRepository>();
builder.Services.AddTransient<IEbayRepository, EbayRepository>();
builder.Services.AddTransient<IMercadoLibreRepository, MercadoLibreRepository>();


builder.Services.AddTransient<IAmazonService, AmazonService>();
builder.Services.AddTransient<IEbayService, EbayService>();
builder.Services.AddTransient<IMercadoLibreService, MercadoLibreService>();


var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapControllers();
app.Run();