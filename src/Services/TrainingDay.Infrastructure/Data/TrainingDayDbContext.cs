using TrainingDay.Core;
using Microsoft.EntityFrameworkCore;
using TrainingDay.Core.AggregatesModel.SkillAggregate;

namespace TrainingDay.Infrastructure.Data;

public class TrainingDayDbContext: DbContext,ITrainingDayDbContext
{
    public TrainingDayDbContext(DbContextOptions<TrainingDayDbContext> options)    : base(options)
    {
    }

    public DbSet<Skill> Skills { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("TrainingDay");

        base.OnModelCreating(modelBuilder);

    }

}

