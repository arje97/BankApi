using System.ComponentModel.DataAnnotations;

namespace Core.Application.RequestsHelper.DTOs;

public class UserDTO : LoginDTO
{
    public string PasswordConfirmed { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PrivateNumber { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
    public DateTime BirthDate { get; set; }
}
