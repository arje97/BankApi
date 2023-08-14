using Core.Application.RequestsHelper.DTOs.LoanDTOs;
using Core.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.BankApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LoansController : ControllerBase
    {
        private readonly LoanService loanService;
        public LoansController(LoanService loanService) => this.loanService = loanService;

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddEditLoanDTO addLoanDTO)
        {
            await loanService.AddLoan(addLoanDTO);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLoans()
        {
            return Ok(await loanService.GetAll());
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AddEditLoanDTO updateLoanDTO)
        {
            await loanService.UpdateLoans(id, updateLoanDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            loanService.unit.LoanRepository.Delete(id);
        }
    }
}
