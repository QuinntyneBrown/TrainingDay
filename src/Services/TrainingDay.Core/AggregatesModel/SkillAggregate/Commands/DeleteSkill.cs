namespace TrainingDay.Core.AggregatesModel.SkillAggregate.Commands;

public class DeleteSkillRequestValidator: AbstractValidator<DeleteSkillRequest>
{
    public DeleteSkillRequestValidator(){

        RuleFor(x => x.SkillId).NotEqual(default(Guid));

    }

}


public class DeleteSkillRequest: IRequest<DeleteSkillResponse>
{
    public Guid SkillId { get; set; }
}


public class DeleteSkillResponse
{
    public required SkillDto Skill { get; set; }
}


public class DeleteSkillRequestHandler: IRequestHandler<DeleteSkillRequest,DeleteSkillResponse>
{
    private readonly ITrainingDayDbContext _context;

    private readonly ILogger<DeleteSkillRequestHandler> _logger;

    public DeleteSkillRequestHandler(ILogger<DeleteSkillRequestHandler> logger,ITrainingDayDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<DeleteSkillResponse> Handle(DeleteSkillRequest request,CancellationToken cancellationToken)
    {
        var skill = await _context.Skills.FindAsync(request.SkillId);

        _context.Skills.Remove(skill);

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            Skill = skill.ToDto()
        };
    }

}


