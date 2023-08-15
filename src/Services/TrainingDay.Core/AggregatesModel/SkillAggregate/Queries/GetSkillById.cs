namespace TrainingDay.Core.AggregatesModel.SkillAggregate.Queries;

public class GetSkillByIdRequest: IRequest<GetSkillByIdResponse>
{
    public Guid SkillId { get; set; }
}


public class GetSkillByIdResponse
{
    public required SkillDto Skill { get; set; }
}


public class GetSkillByIdRequestHandler: IRequestHandler<GetSkillByIdRequest,GetSkillByIdResponse>
{
    private readonly ITrainingDayDbContext _context;

    private readonly ILogger<GetSkillByIdRequestHandler> _logger;

    public GetSkillByIdRequestHandler(ILogger<GetSkillByIdRequestHandler> logger,ITrainingDayDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetSkillByIdResponse> Handle(GetSkillByIdRequest request,CancellationToken cancellationToken)
    {
        return new () {
            Skill = (await _context.Skills.AsNoTracking().SingleOrDefaultAsync(x => x.SkillId == request.SkillId)).ToDto()
        };

    }

}


