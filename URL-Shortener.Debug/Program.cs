using System.Text.Json;
using UrlShortener.Domain.Features.UrlShortening;

Console.WriteLine("Hello, World!");
var request = new AddShortenedUrl.Request("www.facebook.com");
var response = new AddShortenedUrl.Handler().Handle(request, CancellationToken.None);
Console.WriteLine(JsonSerializer.Serialize(response));