using Base62.Conversion;
using FluentResults;
using MediatR;

namespace UrlShortener.Application.Features.UrlShortening;

public sealed class AddShortenedUrl
{
    public sealed record Request(string? Url) : IRequest<Result<Response>>;
    public sealed record Response(Guid Id, string? OriginalUrl, string? ShortenedURL);
    public sealed class Handler : IRequestHandler<Request, Result<Response>>
    {
        // private readonly DbConnection _db;

        // public Handler(DbConnection db)
        // {
        //     _db = db;
        // }

        public async Task<Result<Response>> Handle(Request request, CancellationToken cancellationToken)
        {
            var referenceDate = new DateTime(2024, 01, 01);
            var secondsSinceReferenceDate = (DateTime.UtcNow - referenceDate).TotalSeconds;
            var shortenedUri = Base62Converter.Encode((long)secondsSinceReferenceDate);
            var shortenedUrl = $"localhost:8080/{shortenedUri}";

            return await Task.FromResult(
                Result.Ok(
                    new Response(Guid.NewGuid(), request.Url, shortenedUrl)
                )
            );
        }
    }
}