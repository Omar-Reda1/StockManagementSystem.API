using System.ComponentModel.DataAnnotations;

namespace StockManagementSystem.API.DTOs.Comment
{
    public class UpdateCommentDto
    {
        [Required]
        [MaxLength(280, ErrorMessage = "Tittle Cannot be over 280 Characters")]
        [MinLength(5, ErrorMessage = "Tittle must be over 5 Characters")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(500, ErrorMessage = "Content Cannot be over 280 Character")]
        [MinLength(5, ErrorMessage = "Content must be over 5 Characters")]
        public string Content { get; set; } = string.Empty;
    }
}
