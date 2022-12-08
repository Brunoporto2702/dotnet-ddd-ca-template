using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialCommerce.Application.Authentication.Commands;
using SocialCommerce.Application.Authentication.Commom;
using SocialCommerce.Contracts.Authentication;

namespace SocialCommerce.Api.Controllers;

[Route("auth")]
[ApiController]
public class AuthenticationController : ApiController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        return Ok(request);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        ErrorOr<AuthResult> authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }
}