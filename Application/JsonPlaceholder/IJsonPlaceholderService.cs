using Application.JsonPlaceholder.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.JsonPlaceholder
{
    public interface IJsonPlaceholderService
    {
        Task<List<Album>> GetAlbums(int userId);
        Task<List<Post>> GetPosts(int userId);
        Task<List<ToDo>> GetToDos(int userId);
    }
}
