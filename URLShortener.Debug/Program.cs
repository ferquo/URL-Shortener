using System.Text.Json;
using UrlShortener.Application.Features.UrlShortening;

Console.WriteLine("Hello, World!");
var request = new AddShortenedUrl.Request("www.facebook.com");
var handler = new AddShortenedUrl.Handler();

var response = await handler.Handle(request, CancellationToken.None);
Console.WriteLine(JsonSerializer.Serialize(response.Value));