using System.ComponentModel.DataAnnotations;

namespace StockManagementSystem.API.DTOs.Account
{
    public class LoginDto
    {
        [Required]
        public string UserName { get; set; }=String.Empty;
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }= String.Empty;
    }
}
