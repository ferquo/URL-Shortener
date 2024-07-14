using UrlShortener.Application.Features.UrlShortening;
using URLShortener.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AddShortenedUrl).Assembly));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
        {
            options.EnableTryItOutByDefault();
        });
}
app.UseHttpsRedirection();
app.MapUrlShortenerEndpoints();
app.Run();
