namespace Skills.Core.AggregatesModel.SkillAggregate;

public static class SkillExtensions
{
    public static SkillDto ToDto(this Skill skill)
    {
        return new SkillDto
        {
            SkillId = skill.SkillId,
            Name = skill.Name,
            Description = skill.Description,
        };

    }

    public async static Task<List<SkillDto>> ToDtosAsync(this IQueryable<Skill> skills,CancellationToken cancellationToken)
    {
        return await skills.Select(x => x.ToDto()).ToListAsync(cancellationToken);
    }

}

