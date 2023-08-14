using Core.Application.Interfaces.Repositories;
using Core.Domain;

namespace Infrastructure.Database.Implementations
{
    internal class LoanRepository : Repository<Loan>, ILoanRepository
    {
        public LoanRepository(BankApi_DbContext context) : base(context)
        {

        }

    }
}
