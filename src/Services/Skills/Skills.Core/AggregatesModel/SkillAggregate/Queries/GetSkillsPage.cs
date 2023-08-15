namespace Skills.Core.AggregatesModel.SkillAggregate.Queries;

public class GetSkillsPageRequest: IRequest<GetSkillsPageResponse>
{
    public int PageSize { get; set; }
    public int Index { get; set; }
    public int Length { get; set; }
}


public class GetSkillsPageResponse
{
    public required int Length { get; set; }
    public required List<SkillDto> Entities  { get; set; }
}


public class CreateSkillRequestHandler: IRequestHandler<GetSkillsPageRequest,GetSkillsPageResponse>
{
    private readonly ISkillsDbContext _context;

    private readonly ILogger<CreateSkillRequestHandler> _logger;

    public CreateSkillRequestHandler(ILogger<CreateSkillRequestHandler> logger,ISkillsDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetSkillsPageResponse> Handle(GetSkillsPageRequest request,CancellationToken cancellationToken)
    {
        var query = from skill in _context.Skills
            select skill;

        var length = await _context.Skills.AsNoTracking().CountAsync();

        var skills = await query.Page(request.Index, request.PageSize).AsNoTracking()
            .Select(x => x.ToDto()).ToListAsync();

        return new ()
        {
            Length = length,
            Entities = skills
        };

    }

}


