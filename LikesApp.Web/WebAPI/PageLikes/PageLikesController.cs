using System.Threading.Tasks;
using System.Web.Http;
using LikesApp.Core.PageLikes;
using LikesApp.Infrastructure;

namespace LikesApp.WebAPI.PageLikes
{
    public class PageLikesController : ApiController
    {
        private readonly IPageLikesManager _pageLikesManager;

        public PageLikesController(IPageLikesManager pageLikesManager)
        {
            _pageLikesManager = pageLikesManager;
        }

        [HttpGet]
        [Route("api/PageLikes/Count")]
        public async Task<long> Count([FromUri]string pageName)
        {
            return await _pageLikesManager.GetLikesCountAsync(pageName);
        }

        [HttpGet]
        [Authorize]
        [Route("api/PageLikes/IsLiked")]
        public async Task<bool> IsLiked([FromUri]string pageName)
        {
            return await _pageLikesManager.IsLikedByUserAsync(pageName, this.GetCurrentUserId());
        }

        [HttpPost]
        [Authorize]
        [Route("api/PageLikes/Like")]
        public async Task Like([FromBody]string pageName)
        {
            await _pageLikesManager.LikeAsync(pageName, this.GetCurrentUserId());
        }

        [HttpPost]
        [Authorize]
        [Route("api/PageLikes/Unlike")]
        public async Task Unlike([FromBody]string pageName)
        {
            await _pageLikesManager.UnlikeAsync(pageName, this.GetCurrentUserId());
        }
    }
}
