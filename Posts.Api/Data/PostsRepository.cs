using Posts.Api.Data.Entities;

namespace Posts.Api.Data
{
    public sealed class PostsRepository
    {
        private static readonly object lockObject = new object();
        private static PostsRepository? instance;
        private List<PostEntity> postsEntities;

        private PostsRepository()
        {
            postsEntities = new List<PostEntity>();
        }

        public static PostsRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new PostsRepository();
                        }
                    }
                }
                return instance;
            }
        }

        public void CreatePost(PostEntity postEntity)
        {
            lock (lockObject)
            {
                postsEntities.Add(postEntity);
            }
        }

        public PostEntity? GetPostById(Guid id)
        {
            lock (lockObject)
            {
                return postsEntities.FirstOrDefault(x => x.Id == id);
            }
        }

        public List<PostEntity> GetAllPosts()
        {
            lock (lockObject)
            {
                return new List<PostEntity>(postsEntities);
            }
        }

        public Guid DeletePost(Guid id)
        {
            lock (lockObject)
            {
                var post = postsEntities.FirstOrDefault(x => x.Id == id);
                if (post != null)
                {
                    postsEntities.Remove(post);
                    return id;
                }
                return Guid.Empty;
            }
        }
    }
}
