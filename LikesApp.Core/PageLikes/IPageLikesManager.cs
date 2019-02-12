using System.Threading.Tasks;

namespace LikesApp.Core.PageLikes
{
    public interface IPageLikesManager
    {
        Task<long> GetLikesCountAsync(string pageName);

        Task<bool> IsLikedByUserAsync(string pageName, int userId);

        Task LikeAsync(string pageName, int userId);

        Task UnlikeAsync(string pageName, int userId);
    }
}
