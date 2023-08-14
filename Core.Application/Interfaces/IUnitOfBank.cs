using Core.Application.Interfaces.Repositories;

namespace Core.Application.Interfaces
{
    public interface IUnitOfBank
    {
        public IUserRepository UserRepository { get; }
        public ILoanRepository LoanRepository { get; }
    }
}
