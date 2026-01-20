namespace FlowerApi.Endpoints;


public static class ErrorEndpoints
{
    public static void AddErrorEndpoints(this WebApplication app)
    {
        app.MapGet("/error/{code}", (int code) =>
        {
            return code switch
            {
                400 => Results.BadRequest(new { Message = "This is a bad request." }),
                401 => Results.Unauthorized(),
                403 => Results.Forbid(),
                404 => Results.NotFound(new { Message = "The requested resource was not found." }),
                500 => Results.Problem("An internal server error occurred."),
                _ => Results.StatusCode(code) // Unknown Error
            };
        });
    }
}
