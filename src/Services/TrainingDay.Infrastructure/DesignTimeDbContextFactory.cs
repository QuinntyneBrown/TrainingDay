using TrainingDay.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TrainingDayDbContext>
{
    public TrainingDayDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<TrainingDayDbContext>();

        var basePath = Path.GetFullPath("../TrainingDay.Api");

        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", false)
            .Build();

        var connectionString = configuration.GetConnectionString("DefualtConnection");

        builder.UseSqlServer(connectionString);

        return new TrainingDayDbContext(builder.Options);
    }
}