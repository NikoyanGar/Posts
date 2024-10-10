using Microsoft.AspNetCore.Mvc;
using Posts.Api.Data;
using Posts.Api.Data.Entities;
using Posts.Api.Models.RequestModels;
using Posts.Api.Models.ResponseModels;
using Posts.Api.Services;

namespace Posts.Api.Controllers
{
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly PostsRepository _postsRepository;

        public PostsController()
        {
            _postsRepository = PostsRepository.Instance;
        }

        [HttpPost]
        public PostCreationResponse CreatePost(PostCrerationRequest postCreationRequest, [FromHeader] string userKey)
        {
            int userID = AuthentificationService.GetUserId(userKey);
            PostEntity post = new PostEntity
            {
                Id = postCreationRequest.Id,
                Title = postCreationRequest.Title,
                Content = postCreationRequest.Content,
                UserId = userID
            };

            _postsRepository.CreatePost(post);

            return new PostCreationResponse(post.Title, post.Id, post.Content);
        }

        [HttpGet]
        [Route("{id}")]
        public PostCreationResponse GetPostById([FromRoute] Guid id)
        {
            return new PostCreationResponse(id);
        }

        [HttpGet]
        public List<PostCreationResponse> GetAllPosts([FromHeader] string userKey)
        {
            var id = AuthentificationService.GetUserId(userKey);
            var entities = _postsRepository.GetAllPosts();
            return entities.Where(x => x.UserId == id).Select(x => new PostCreationResponse(x.Title, x.Id, x.Content)).ToList();
        }
    }
}
