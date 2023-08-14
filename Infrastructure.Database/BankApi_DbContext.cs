using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    internal class BankApi_DbContext: DbContext
    {
        public BankApi_DbContext(DbContextOptions<BankApi_DbContext> options) : base(options) { }
        public DbSet<User> Users { get; private set; }
        public DbSet<Loan> Loans { get; private set; }
    }
}
