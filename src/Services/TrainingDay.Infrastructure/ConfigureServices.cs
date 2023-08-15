using TrainingDay.Core;
using TrainingDay.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static void AddInfrastructureServices(this IServiceCollection services, string connectionString)
    {

        services.AddScoped<ITrainingDayDbContext, TrainingDayDbContext>();
        services.AddDbContextPool<TrainingDayDbContext>(options =>
        {
            options.UseSqlServer(connectionString, builder => builder.MigrationsAssembly("TrainingDay.Infrastructure"))
            .EnableThreadSafetyChecks(false);
        });
    }
}