using JwtApp.Back.Core.Application.Features.CQRS.Commands;
using JwtApp.Back.Core.Application.Features.CQRS.Queries;
using JwtApp.Back.Infrastructure.Tools;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using System.IdentityModel.Tokens.Jwt;

namespace JwtApp.Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserCommandRequest request)
        {
            await this._mediator.Send(request);
            return Created("", request);
        }

        [HttpPost]
        public async Task<IActionResult> Login(CheckUserQueryRequest request)
        {
            var dto = await this._mediator.Send(request);
            if (dto.IsExist)
            {
                return Created("", JwtTokenGenerator.GenerateToken(dto));
            }
            else
            {
                return BadRequest("Kullanıcı adı veya şifre hatalı");
            }
        } 
    }
}
