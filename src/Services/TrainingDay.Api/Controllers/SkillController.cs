using TrainingDay.Core.AggregatesModel.SkillAggregate.Commands;
using TrainingDay.Core.AggregatesModel.SkillAggregate.Queries;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Swashbuckle.AspNetCore.Annotations;

namespace TrainingDay.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/{version:apiVersion}/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
public class SkillController
{
    private readonly IMediator _mediator;

    private readonly ILogger<SkillController> _logger;

    public SkillController(IMediator mediator,ILogger<SkillController> logger){
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [SwaggerOperation(
        Summary = "Update Skill",
        Description = @"Update Skill"
    )]
    [HttpPut(Name = "updateSkill")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(UpdateSkillResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<UpdateSkillResponse>> Update([FromBody]UpdateSkillRequest  request,CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }

    [SwaggerOperation(
        Summary = "Create Skill",
        Description = @"Create Skill"
    )]
    [HttpPost(Name = "createSkill")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(CreateSkillResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CreateSkillResponse>> Create([FromBody]CreateSkillRequest  request,CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }

    [SwaggerOperation(
        Summary = "Get Skills",
        Description = @"Get Skills"
    )]
    [HttpGet(Name = "getSkills")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetSkillsResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetSkillsResponse>> Get(CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetSkillsRequest(), cancellationToken);
    }

    [SwaggerOperation(
        Summary = "Get Skill by id",
        Description = @"Get Skill by id"
    )]
    [HttpGet("{skillId:guid}", Name = "getSkillById")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetSkillByIdResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetSkillByIdResponse>> GetById([FromRoute]Guid skillId,CancellationToken cancellationToken)
    {
        var request = new GetSkillByIdRequest(){SkillId = skillId};

        var response = await _mediator.Send(request, cancellationToken);

        if (response.Skill == null)
        {
            return new NotFoundObjectResult(request.SkillId);
        }

        return response;
    }

    [SwaggerOperation(
        Summary = "Delete Skill",
        Description = @"Delete Skill"
    )]
    [HttpDelete("{skillId:guid}", Name = "deleteSkill")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(DeleteSkillResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<DeleteSkillResponse>> Delete([FromRoute]Guid skillId,CancellationToken cancellationToken)
    {
        var request = new DeleteSkillRequest() {SkillId = skillId };

        return await _mediator.Send(request, cancellationToken);
    }

}

