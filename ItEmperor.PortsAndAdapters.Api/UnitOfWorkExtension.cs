using ItEmperor.PortsAndAdapters.DalLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ItEmperor.PortsAndAdapters.Api
{
    public static class UnitOfWorkExtension
    {
        public static void UseUnitOfWorkMiddleware(this WebApplication webApplication)
        {
            webApplication.Use(async (context, next) =>
            {
                await next();
                var dbContext = context.RequestServices.GetService<BoardDbContext>();
                await dbContext.SaveChangesAsync();
            });
        }
    }
}