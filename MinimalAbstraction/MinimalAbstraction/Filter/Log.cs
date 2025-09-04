using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Cloudito.Services.Common;

public class LoggingFilter<TEndpoint> : IEndpointFilter
{
    private readonly ILogger _logger;

    public LoggingFilter(ILogger<TEndpoint> logger)
    {
        _logger = logger;
    }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var endpoint = typeof(TEndpoint);
        _logger.LogInformation($"Request for {endpoint.Name}");
        object? result = await next.Invoke(context);
        _logger.LogInformation($"Response for {endpoint.Name} : Response Object is : {result}");
        return result;
    }
}

public class LoggingFilter<TEndpoint, TRequest> : IEndpointFilter
{
    private readonly ILogger<TEndpoint> _logger;

    public LoggingFilter(ILogger<TEndpoint> logger)
    {
        _logger = logger;
    }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        int index = context.Arguments.IndexOf(context.Arguments.FirstOrDefault(x => x?.GetType() == typeof(TRequest)));
        TRequest? inputData = context.GetArgument<TRequest>(index);

        Type endpoint = typeof(TEndpoint);
        _logger.LogInformation($"Request for {endpoint.Name}");
        object? result = await next.Invoke(context);
        _logger.LogInformation($"Response for {endpoint.Name}");
        return result;

    }
}


public static class LoggingExtension
{
    public static RouteHandlerBuilder Log<TEndpoint, TRequest>(this RouteHandlerBuilder handlerBuilder)
        where TEndpoint : IEndpoint
    {
        handlerBuilder.AddEndpointFilter<LoggingFilter<TEndpoint, TRequest>>();
        return handlerBuilder;
    }

    public static RouteHandlerBuilder Log<TEndpoint>(this RouteHandlerBuilder handlerBuilder)
       where TEndpoint : IEndpoint
    {
        handlerBuilder.AddEndpointFilter<LoggingFilter<TEndpoint>>();
        return handlerBuilder;
    }
}
