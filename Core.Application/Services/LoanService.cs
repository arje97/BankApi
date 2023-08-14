using AutoMapper;
using Core.Application.Interfaces;
using Core.Application.RequestsHelper.DTOs.LoanDTOs;
using Core.Domain;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Core.Application.Services
{
    public class LoanService
    {
        public IMapper mapper { get; }
        public IUnitOfBank unit { get; }
        private readonly IHttpContextAccessor httpContextAccessor;

        public LoanService(IUnitOfBank unit, IMapper mapper, IHttpContextAccessor httpContextAccessor) => (this.unit, this.mapper, this.httpContextAccessor) = (unit, mapper, httpContextAccessor);

        public async Task<IEnumerable<GetLoansDTO>> GetAll()
        {

            int userId = int.Parse(this.httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);

            var allLoans = await unit.LoanRepository.GetAll(y => y.User.Id == userId);

            return mapper.Map<List<GetLoansDTO>>(allLoans);
        }

        public async Task AddLoan(AddEditLoanDTO addLoanDTO)
        {
            int userId = int.Parse(this.httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);

            await unit.LoanRepository.Create(new Loan
            {
                Amount = addLoanDTO.Amount,
                Period = addLoanDTO.Period,
                UserId = userId
            });
        }

        public async Task UpdateLoans(int id, AddEditLoanDTO updateloantDTO)
        {

            int userId = int.Parse(this.httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);

            var loan = await unit.LoanRepository.GetById(id);

            if (loan.UserId != userId)
            {
                throw new Exception("Not allowed");
            }

            loan.Amount = updateloantDTO.Amount;
            loan.Period = updateloantDTO.Period;

            await unit.LoanRepository.Update(loan);


        }


    }
}
