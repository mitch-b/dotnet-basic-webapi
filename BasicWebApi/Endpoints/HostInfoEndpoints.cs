using BasicWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebApi.Endpoints
{
    public static class HostInfoEndpoints
    {
        public static RouteGroupBuilder MapHostInfoApi(this RouteGroupBuilder group)
        {
            group.MapGet("/", GetHostInfo);
            group.MapGet("/2", GetHostInfo2)
                .WithName("GetHostInfo2")
                .WithSummary("Returns host information to any client")
                .WithDescription("Example endpoint which returns simple host information")
                .Produces(200, typeof(HostInfo))
                .WithOpenApi(operation => new(operation) { Deprecated = true });
            return group;
        }

        [EndpointName("GetHostInfo")]
        [EndpointSummary("Returns host information to any client")]
        [EndpointDescription("Example endpoint which returns simple host information")]
        [Produces(typeof(HostInfo))]
        public static async Task<HostInfo> GetHostInfo([FromServices] IHttpContextAccessor httpContextAccessor)
        {
            return new HostInfo
            {
                HostIp = httpContextAccessor?.HttpContext?.Connection?.LocalIpAddress?.ToString()
            };
        }

        public static async Task<HostInfo> GetHostInfo2([FromServices] IHttpContextAccessor httpContextAccessor)
        {
            return new HostInfo
            {
                HostIp = httpContextAccessor?.HttpContext?.Connection?.LocalIpAddress?.ToString()
            };
        }
    }
}
