using Microsoft.AspNetCore.Routing;

namespace Cloudito.Services.Common;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}