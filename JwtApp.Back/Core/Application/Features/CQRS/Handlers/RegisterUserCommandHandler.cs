using JwtApp.Back.Core.Application.Enums;
using JwtApp.Back.Core.Application.Features.CQRS.Commands;
using JwtApp.Back.Core.Application.Interfaces;
using JwtApp.Back.Core.Domain;
using MediatR;

namespace JwtApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest>
    {

        private readonly IRepository<AppUser> repository;

        public RegisterUserCommandHandler(IRepository<AppUser> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            await this.repository.CreateAsync(new AppUser
            {
                Username = request.Username,
                Password = request.Password,
                AppRoleId = (int)RoleType.Member
            });
            return Unit.Value;
        }
    }
}
