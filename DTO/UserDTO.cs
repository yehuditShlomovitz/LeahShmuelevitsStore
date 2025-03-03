using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record  UserDTO([EmailAddress(ErrorMessage ="כתובת מייל לא תקינה"),Required] string UserName, string? FirstName,string? LastName, [Required] string Password);
    public record  GetUserDTO([EmailAddress(ErrorMessage = "כתובת מייל לא תקינה"), Required] string UserName, string? FirstName, string? LastName);

}
