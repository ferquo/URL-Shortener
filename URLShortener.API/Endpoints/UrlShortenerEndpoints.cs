namespace URLShortener.API;

public static class UrlShortenerEndpoints
{
    public static void MapUrlShortenerEndpoints(this WebApplication app)
    {
        app.MapGet("/api/shortener", () =>
        {
            return Results.Ok("Hello, World!");
        })
        .WithName("GetUrlShortener")
        .WithOpenApi();
    }
}
