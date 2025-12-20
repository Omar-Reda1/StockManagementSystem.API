using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockManagementSystem.API.DTOs.Comment;
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
        private readonly IStockRepository _stockRepository;

        public CommentsController(ICommentRepository commentRepository, IStockRepository stockRepository)
        {
            _commentRepository = commentRepository;
            _stockRepository = stockRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepository.GetAllAsync();

            var commentDto = comments.Select(s => s.ToCommentDto());

            return Ok(commentDto);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);

            if (comment == null)
                return NotFound();

            return Ok(comment.ToCommentDto());
        }

        [HttpPost("Create/{stockId}")]
        public async Task<IActionResult> Create(int stockId, CreateCommentDto commentDto)
        {
            if (!await _stockRepository.IsStockExists(stockId))
            {
                return BadRequest("Stock Does Not Exist");
            }

            var commentModel = commentDto.ToCommentFromCreate(stockId);

            await _commentRepository.CreateAsync(commentModel);

            return CreatedAtAction(nameof(GetById), new { id = commentModel.Id }, commentModel.ToCommentDto());
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id , UpdateCommentDto updateDto)
        {
            var comment =await _commentRepository.UpdateAsync(id, updateDto.ToCommentFromUpdate());

            if(comment is null)
                return NotFound("Comment Not Found");

            return Ok(comment.ToCommentDto());
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var commentModel =await _commentRepository.DeleteAsync(id);
            if (commentModel is null)
                return NotFound();

            return NoContent();
        }

    }
}
