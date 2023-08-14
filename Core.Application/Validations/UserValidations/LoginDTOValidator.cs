using Core.Application.Interfaces;
using Core.Application.RequestsHelper.DTOs;
using FluentValidation;

namespace Core.Application.Validations.UserValidations
{
    public class LoginDTOValidator : AbstractValidator<LoginDTO>
    {
        private readonly IUnitOfBank unit;
        public LoginDTOValidator(IUnitOfBank unit)
        {
            this.unit = unit;

            RuleFor(x => x.UserName).MustAsync(async (o, username, cancellation) =>
            {
                return await ValidateUser(username, o.Password);
            }).WithMessage("იუზერი ან პაროლი არასწორია");

        }
        public async Task<bool> ValidateUser(string username, string password)
        {
            var exists = await unit.UserRepository.ValidateUser(username, password);
            if (exists != null)
                return true;
            else
                return false;
        }


    }
  
}
