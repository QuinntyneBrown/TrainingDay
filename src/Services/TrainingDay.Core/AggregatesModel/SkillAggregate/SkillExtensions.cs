namespace TrainingDay.Core.AggregatesModel.SkillAggregate;

public static class SkillExtensions
{
    public static SkillDto ToDto(this Skill skill)
    {
        return new SkillDto
        {
            Title = skill.Title,
            IsComplete = skill.IsComplete,
            SkillId = skill.SkillId,
        };

    }

    public async static Task<List<SkillDto>> ToDtosAsync(this IQueryable<Skill> skills,CancellationToken cancellationToken)
    {
        return await skills.Select(x => x.ToDto()).ToListAsync(cancellationToken);
    }

}

