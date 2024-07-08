using Base62.Conversion;
using MediatR;

public class AddShortenedUrl
{
    public record Request(string? Url) : IRequest<Response>;
    public record Response(Guid Id, string? OriginalUrl, string? ShortenedURL);
    public class Handler : IRequestHandler<Request, Response>
    {
        // private readonly DbConnection _db;

        // public Handler(DbConnection db)
        // {
        //     _db = db;
        // }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var referenceDate = new DateTime(2024, 01, 01);
            var secondsSinceReferenceDate = (DateTime.UtcNow - referenceDate).TotalSeconds;
            var shortenedUri = Base62Converter.Encode((long)secondsSinceReferenceDate);
            var shortenedUrl = $"localhost:8080/{shortenedUri}";

            return await Task.FromResult(new Response(Guid.NewGuid(), request.Url, shortenedUrl));
        }
    }
}