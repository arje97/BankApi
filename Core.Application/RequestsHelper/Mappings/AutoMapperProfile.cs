using AutoMapper;
using Core.Application.RequestsHelper.DTOs;
using Core.Application.RequestsHelper.DTOs.LoanDTOs;
using Core.Domain;

namespace Core.Application.RequestsHelper.Mappings
{
    internal class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateUsersMapping();
            CreateLoansMapping();
        }
        private void CreateUsersMapping()
        {
            CreateMap<UserDTO, User>();
        }
        private void CreateLoansMapping()
        {
            CreateMap<Loan, GetLoansDTO>();
        }
    }
}
