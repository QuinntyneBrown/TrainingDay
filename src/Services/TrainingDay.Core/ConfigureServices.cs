using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using TrainingDay.Core;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static void AddCoreServices(this IServiceCollection services, IWebHostEnvironment environment, IConfiguration configuration)
    { 
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblyContaining<ITrainingDayDbContext>());
        services.AddValidatorsFromAssemblyContaining<ITrainingDayDbContext>();
    }
}