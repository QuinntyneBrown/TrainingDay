using Skills.Core;
using Microsoft.EntityFrameworkCore;
using Skills.Core.AggregatesModel.SkillAggregate;

namespace Skills.Infrastructure.Data;

public class SkillsDbContext: DbContext,ISkillsDbContext
{
    public SkillsDbContext(DbContextOptions<SkillsDbContext> options)    : base(options)
    {
    }

    public DbSet<Skill> Skills { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Skills");

        base.OnModelCreating(modelBuilder);

    }

}

