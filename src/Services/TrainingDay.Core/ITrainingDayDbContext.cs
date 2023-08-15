using TrainingDay.Core.AggregatesModel.SkillAggregate;

namespace TrainingDay.Core;

public interface ITrainingDayDbContext
{
    DbSet<Skill> Skills { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}

