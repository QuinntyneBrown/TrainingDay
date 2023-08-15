namespace Skills.Core.AggregatesModel.SkillAggregate.Queries;

public class GetSkillsRequest: IRequest<GetSkillsResponse> { }

public class GetSkillsResponse
{
    public required List<SkillDto> Skills { get; set; }
}


public class GetSkillsRequestHandler: IRequestHandler<GetSkillsRequest,GetSkillsResponse>
{
    private readonly ISkillsDbContext _context;

    private readonly ILogger<GetSkillsRequestHandler> _logger;

    public GetSkillsRequestHandler(ILogger<GetSkillsRequestHandler> logger,ISkillsDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetSkillsResponse> Handle(GetSkillsRequest request,CancellationToken cancellationToken)
    {
        return new () {
            Skills = await _context.Skills.AsNoTracking().ToDtosAsync(cancellationToken)
        };

    }

}


