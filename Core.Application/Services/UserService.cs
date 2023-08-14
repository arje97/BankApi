using AutoMapper;
using Core.Application.Interfaces;
using Core.Application.RequestsHelper.DTOs;
using Core.Domain;

namespace Core.Application.Services
{
    public class UserService
    {
        public IMapper mapper { get; }
        public IUnitOfBank unit { get; }

        public UserService(IUnitOfBank unit, IMapper mapper) => (this.unit, this.mapper) = (unit, mapper);
        public async Task RegisterUser(UserDTO userDTO)
        {
            userDTO.Password = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);
            var user = mapper.Map<User>(userDTO);
            await unit.UserRepository.Create(user);
        }

    }
}
