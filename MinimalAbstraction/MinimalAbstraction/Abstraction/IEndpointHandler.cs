using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Cloudito.Services.Common;

public interface IEndpointHandler<TRequest>
{
    Task<ApiModel> HandlerAsync(TRequest request, IMediator mediator, IMapper mapper, CancellationToken cancellationToken);
}

public interface IEndpointHandler
{
    Task<ApiModel> HandlerAsync(IMediator mediator, IMapper mapper, CancellationToken cancellationToken);
}

public interface IContextEndpointHandler<TFinder, TRequest>
{
    Task<ApiModel> HandlerAsync(HttpContext httpContext, TRequest request, TFinder finder, IMediator mediator, IMapper mapper, CancellationToken cancellationToken);
}

public interface IContextEndpointHandler<TFinder>
{
    Task<ApiModel> HandlerAsync(HttpContext httpContext, TFinder finder, IMediator mediator, IMapper mapper, CancellationToken cancellationToken);
}

public interface IContextEndpointHandler<TFinder, TSecondFinder, TRequest>
{
    Task<ApiModel> HandlerAsync(HttpContext httpContext, TRequest request, TFinder finder, TSecondFinder secondFinder, IMediator mediator, IMapper mapper, CancellationToken cancellationToken);
}