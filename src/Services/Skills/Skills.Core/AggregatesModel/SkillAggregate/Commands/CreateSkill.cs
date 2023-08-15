namespace Skills.Core.AggregatesModel.SkillAggregate.Commands;

public class CreateSkillRequestValidator: AbstractValidator<CreateSkillRequest>
{
    public CreateSkillRequestValidator(){

        RuleFor(x => x.Name).NotNull();
        RuleFor(x => x.Description).NotNull();

    }

}


public class CreateSkillRequest: IRequest<CreateSkillResponse>
{
    public string Name { get; set; }
    public string Description { get; set; }
}


public class CreateSkillResponse
{
    public required SkillDto Skill { get; set; }
}


public class CreateSkillRequestHandler: IRequestHandler<CreateSkillRequest,CreateSkillResponse>
{
    private readonly ISkillsDbContext _context;

    private readonly ILogger<CreateSkillRequestHandler> _logger;

    public CreateSkillRequestHandler(ILogger<CreateSkillRequestHandler> logger,ISkillsDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<CreateSkillResponse> Handle(CreateSkillRequest request,CancellationToken cancellationToken)
    {
        var skill = new Skill();

        _context.Skills.Add(skill);

        skill.Name = request.Name;
        skill.Description = request.Description;

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            Skill = skill.ToDto()
        };

    }

}


