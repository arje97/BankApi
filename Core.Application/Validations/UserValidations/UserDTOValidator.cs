using Core.Application.Interfaces;
using Core.Application.RequestsHelper.DTOs;
using FluentValidation;

namespace Core.Application.Validations.UserValidations
{
    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        public readonly IUnitOfBank unit;

        public UserDTOValidator(IUnitOfBank unit)
        {
            this.unit = unit;

            RuleFor(x => x.PrivateNumber).NotEmpty().WithMessage("აუცილებელი ველი");

            RuleFor(x => x.UserName).MustAsync(async (username, cancellation) =>
            {
                bool exists = await unit.UserRepository.ExistedUser(username);
                return !exists;
            }).WithMessage("მითითებული UserName უკვე არსებობს");


            RuleFor(x => x).Must(x => x.Password == x.PasswordConfirmed)
            .WithMessage(" პაროლები არ ემთხვევა ერთმანეთს");

            RuleFor(x => x.FirstName).NotEmpty().WithMessage("აუცილებელი ველი");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("აუცილებელი ველი");

        }

      
    }

}
