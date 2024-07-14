using MediatR;
using UrlShortener.Application.Features.UrlShortening;

namespace URLShortener.API;

public static class UrlShortenerEndpoints
{
    public static void MapUrlShortenerEndpoints(this WebApplication app)
    {
        app.MapPost("/api/urls", async (IMediator mediator, AddShortenedUrl.Request request) =>
        {
            var result = await mediator.Send(new AddShortenedUrl.Request("www.facebook.com"));
            return result.MapToHttpResult();
        })
        .Produces<AddShortenedUrl.Response>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .WithName("PostShortenUrl")
        .WithOpenApi();
    }
}
