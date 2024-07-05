using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Entities
{
  public class Account : DefaultDB
  {


    [Required]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "The Login must be at least 6 characters long.")]
    public String Login { get; set; } = "";

    [Required]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "The Password must be at least 6 characters long.")]
    public string Password { get; set; } = "";

    [Required]
    [EmailAddress(ErrorMessage = "The email address is not valid.")]
    public string Email { get; set; } = "";
  }
}
