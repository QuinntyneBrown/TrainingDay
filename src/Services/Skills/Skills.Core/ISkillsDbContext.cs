using Skills.Core;
using Microsoft.EntityFrameworkCore;
using Skills.Core.AggregatesModel.SkillAggregate;

namespace Skills.Core;

public interface ISkillsDbContext
{
    DbSet<Skill> Skills { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}

