using Core.Domain;

namespace Core.Application.Interfaces.Repositories;

public interface IUserRepository:IRepository<User>
{
    Task<User> ValidateUser(string userName, string password);
    Task<bool> ExistedUser(string userName);
}
