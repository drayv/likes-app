using System.Threading.Tasks;
using LikesApp.Core.Entities;

namespace LikesApp.EntityFramework.Repositories.PageLikes
{
    public interface IPageLikesRepository
    {
        Task CreateAsync(PageLike pageLike);

        Task<PageLike> SearchAsync(string pageName, int userId);

        Task<long> CountAsync(string pageName);

        Task DeleteAsync(PageLike pageLike);
    }
}
