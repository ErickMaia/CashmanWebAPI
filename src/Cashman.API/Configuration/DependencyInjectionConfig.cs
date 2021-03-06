using System.Globalization;
using Cashman.BLL.Interfaces;
using Cashman.BLL.Notifications;
using Cashman.BLL.Services;
using Cashman.DAL.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Cashman.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencies(this IServiceCollection services){
            services.AddScoped<IMovementRepository, MovementRepository>(); 
            services.AddScoped<INotificator, Notificator>(); 
            services.AddScoped<IMovementService, MovementService>(); 
        } 
    }
}