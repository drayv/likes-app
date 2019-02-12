using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using LikesApp.Core.PageLikes;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Web;

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
            return await _pageLikesManager.IsLikedByUserAsync(pageName, GetCurrentUserId());
        }

        [HttpPost]
        [Authorize]
        [Route("api/PageLikes/Like")]
        public async Task Like([FromBody]string pageName)
        {
            await _pageLikesManager.LikeAsync(pageName, GetCurrentUserId());
        }

        [HttpPost]
        [Authorize]
        [Route("api/PageLikes/Unlike")]
        public async Task Unlike([FromBody]string pageName)
        {
            await _pageLikesManager.UnlikeAsync(pageName, GetCurrentUserId());
        }

        // TODO: Move to base API Controller
        private int GetCurrentUserId()
        {
            try
            {
                return HttpContext.Current.User.Identity.GetUserId<int>();
            }
            catch
            {
                return 0;
            }
        }
    }
}
