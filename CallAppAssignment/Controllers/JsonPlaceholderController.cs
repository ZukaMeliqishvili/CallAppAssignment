using Application.JsonPlaceholder;
using Application.JsonPlaceholder.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CallAppAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class JsonPlaceholderController : ControllerBase
    {
        private readonly IJsonPlaceholderService _jsonPlaceholderService;

        public JsonPlaceholderController(IJsonPlaceholderService jsonPlaceholderService)
        {
            _jsonPlaceholderService = jsonPlaceholderService;
        }
        [HttpGet("todos/{userId}")]
        public async Task<List<ToDo>> GetTodos(int userId) 
        {
            return await _jsonPlaceholderService.GetToDos(userId);
        }
        [HttpGet("albums/{userId}")]
        public async Task<List<Album>> GetAlbums(int userId)
        {
            return await _jsonPlaceholderService.GetAlbums(userId);
        }
        [HttpGet("posts/{userId}")]
        public async Task<List<Post>> GetPosts(int userId)
        {
            return await _jsonPlaceholderService.GetPosts(userId);
        }
    }
}
