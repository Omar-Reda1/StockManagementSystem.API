using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockManagementSystem.API.Mappers;
using StockManagementSystem.API.Repositories.IRepositories;
using System.Threading.Tasks;

namespace StockManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;

        public CommentsController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var comments= await _commentRepository.GetAllAsync();

            var commentDto = comments.Select(s => s.ToCommentDto());

            return Ok(commentDto);    
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var comment =await _commentRepository.GetByIdAsync(id);

            if (comment == null) 
                return NotFound();

            return Ok(comment.ToCommentDto());
        }

    }
}
