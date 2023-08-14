using Core.Application.Interfaces;
using Core.Application.Interfaces.Repositories;
using Infrastructure.Database.Implementations;

namespace Infrastructure.Database
{
    internal class UnitOfBank : IUnitOfBank
    {
        private IUserRepository userRepository;
        private ILoanRepository loanRepository;


        private BankApi_DbContext dbContext;
        public UnitOfBank(BankApi_DbContext dbContext) => this.dbContext = dbContext;

        public IUserRepository UserRepository => userRepository ??= new UserRepository(dbContext);
        public ILoanRepository LoanRepository => loanRepository ??= new LoanRepository(dbContext);
    }
}
