namespace TrainingDay.Core.AggregatesModel.SkillAggregate.Commands;

public class CreateSkillRequestValidator: AbstractValidator<CreateSkillRequest>
{
    public CreateSkillRequestValidator(){

        RuleFor(x => x.Title).NotNull();
        RuleFor(x => x.IsComplete).NotNull();

    }

}


public class CreateSkillRequest: IRequest<CreateSkillResponse>
{
    public string Title { get; set; }
    public bool IsComplete { get; set; }
}


public class CreateSkillResponse
{
    public required SkillDto Skill { get; set; }
}


public class CreateSkillRequestHandler: IRequestHandler<CreateSkillRequest,CreateSkillResponse>
{
    private readonly ITrainingDayDbContext _context;

    private readonly ILogger<CreateSkillRequestHandler> _logger;

    public CreateSkillRequestHandler(ILogger<CreateSkillRequestHandler> logger,ITrainingDayDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<CreateSkillResponse> Handle(CreateSkillRequest request,CancellationToken cancellationToken)
    {
        var skill = new Skill();

        _context.Skills.Add(skill);

        skill.Title = request.Title;
        skill.IsComplete = request.IsComplete;

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            Skill = skill.ToDto()
        };

    }

}


