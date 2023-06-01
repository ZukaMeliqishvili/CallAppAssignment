using Application.JsonPlaceholder.Response;
using Newtonsoft.Json;

namespace Application.JsonPlaceholder
{
    public class JsonPlaceholderService : IJsonPlaceholderService
    {
        private readonly Uri uri;
        private readonly HttpClient httpClient;
        public JsonPlaceholderService()
        {
            uri = new Uri("https://jsonplaceholder.typicode.com/");
            httpClient = new HttpClient()
            {
                BaseAddress = uri,
            };
        }
        public async Task<List<ToDo>> GetToDos(int userId)
        {
            var response = await httpClient.GetAsync("todos");
            var responseString = await response.Content.ReadAsStringAsync();
            var toDos = JsonConvert.DeserializeObject<List<ToDo>>(responseString).Where(x=>x.UserId==userId).ToList();
            if(toDos.Count==0)
            {
                throw new Exception("No record was found");
            }
            return toDos;
        }
        public async Task<List<Album>> GetAlbums(int userId)
        {
            var response = await httpClient.GetAsync("albums");
            var responseString = await response.Content.ReadAsStringAsync();
            var albums = JsonConvert.DeserializeObject<List<Album>>(responseString).Where(x => x.UserId == userId).ToList();
            if(albums.Count==0)
            {
                throw new Exception("No record was found");
            }
            return albums;
        }
        public async Task<List<Post>> GetPosts(int  userId)
        {
            var response = await httpClient.GetAsync("posts?_embed=comments");
            var responseString = await response.Content.ReadAsStringAsync();
            var posts = JsonConvert.DeserializeObject<List<Post>>(responseString).Where(x=>x.UserId==userId).ToList();
            if(posts.Count==0) 
            {
                throw new Exception("No record was found");
            }
            return posts;
        }
    }
}
