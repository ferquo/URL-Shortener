using Base62.Conversion;
using FluentResults;
using MediatR;

namespace UrlShortener.Application.Features.UrlShortening;

public sealed class AddShortenedUrl
{
    public sealed record Request(string? OriginalUrl) : IRequest<Result<Response>>;
    public sealed record Response(Guid Id, string? OriginalUrl, string? ShortenedURL);
    public sealed class Handler : IRequestHandler<Request, Result<Response>>
    {
        public async Task<Result<Response>> Handle(Request request, CancellationToken cancellationToken)
        {
            var referenceDate = new DateTime(2024, 01, 01);
            var milisecondsSinceReferenceDate = (DateTime.UtcNow - referenceDate).TotalMilliseconds;
            var shortenedUri = Base62Converter.Encode((long)milisecondsSinceReferenceDate);
            var shortenedUrl = $"localhost:8080/{shortenedUri}";

            return await Task.FromResult(
                Result.Ok(
                    new Response(Guid.NewGuid(), request.OriginalUrl, shortenedUrl)
                )
            );
        }
    }
}