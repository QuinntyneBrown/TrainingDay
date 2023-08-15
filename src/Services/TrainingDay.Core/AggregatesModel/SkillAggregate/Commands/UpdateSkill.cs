namespace TrainingDay.Core.AggregatesModel.SkillAggregate.Commands;

public class UpdateSkillRequestValidator: AbstractValidator<UpdateSkillRequest>
{
    public UpdateSkillRequestValidator(){

        RuleFor(x => x.Title).NotNull();
        RuleFor(x => x.IsComplete).NotNull();
        RuleFor(x => x.SkillId).NotEqual(default(Guid));

    }

}


public class UpdateSkillRequest: IRequest<UpdateSkillResponse>
{
    public string Title { get; set; }
    public bool IsComplete { get; set; }
    public Guid SkillId { get; set; }
}


public class UpdateSkillResponse
{
    public required SkillDto Skill { get; set; }
}


public class UpdateSkillRequestHandler: IRequestHandler<UpdateSkillRequest,UpdateSkillResponse>
{
    private readonly ITrainingDayDbContext _context;

    private readonly ILogger<UpdateSkillRequestHandler> _logger;

    public UpdateSkillRequestHandler(ILogger<UpdateSkillRequestHandler> logger,ITrainingDayDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<UpdateSkillResponse> Handle(UpdateSkillRequest request,CancellationToken cancellationToken)
    {
        var skill = await _context.Skills.SingleAsync(x => x.SkillId == request.SkillId);

        skill.Title = request.Title;
        skill.IsComplete = request.IsComplete;
        skill.SkillId = request.SkillId;

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            Skill = skill.ToDto()
        };

    }

}


