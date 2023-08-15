namespace Skills.Core.AggregatesModel.SkillAggregate.Commands;

public class UpdateSkillRequestValidator: AbstractValidator<UpdateSkillRequest>
{
    public UpdateSkillRequestValidator(){

        RuleFor(x => x.SkillId).NotEqual(default(Guid));
        RuleFor(x => x.Name).NotNull();
        RuleFor(x => x.Description).NotNull();

    }

}


public class UpdateSkillRequest: IRequest<UpdateSkillResponse>
{
    public Guid SkillId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}


public class UpdateSkillResponse
{
    public required SkillDto Skill { get; set; }
}


public class UpdateSkillRequestHandler: IRequestHandler<UpdateSkillRequest,UpdateSkillResponse>
{
    private readonly ISkillsDbContext _context;

    private readonly ILogger<UpdateSkillRequestHandler> _logger;

    public UpdateSkillRequestHandler(ILogger<UpdateSkillRequestHandler> logger,ISkillsDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<UpdateSkillResponse> Handle(UpdateSkillRequest request,CancellationToken cancellationToken)
    {
        var skill = await _context.Skills.SingleAsync(x => x.SkillId == request.SkillId);

        skill.SkillId = request.SkillId;
        skill.Name = request.Name;
        skill.Description = request.Description;

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            Skill = skill.ToDto()
        };

    }

}


