using Core.Application.Interfaces.Repositories;
using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Implementations
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(BankApi_DbContext context) : base(context)
        {

        }

        public async Task<bool> ExistedUser(string userName)
        {
            return await context.Users.AnyAsync(x => x.UserName == userName);
        }

        public async Task<User> ValidateUser(string userName, string password)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
                return user;
            else
                return null;

        }
    }
}
