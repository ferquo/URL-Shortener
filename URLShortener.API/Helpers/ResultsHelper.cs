namespace URLShortener.API;

public static class ResultsHelper
{
    public static IResult MapToHttpResult<T>(this FluentResults.Result<T> result)
    {
        if (result.IsFailed)
        {
            var errors = result.Errors.Select(e => new { e.Message });
            return Results.BadRequest(errors);
        }

        return TypedResults.Ok(result.Value);
    }
}
