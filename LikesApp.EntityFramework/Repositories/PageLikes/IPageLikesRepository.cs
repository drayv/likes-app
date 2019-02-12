using System.Threading.Tasks;
using LikesApp.Core.Entities;

namespace LikesApp.EntityFrameworkCore.Repositories.PageLikes
{
    public interface IPageLikesRepository
    {
        Task CreateAsync(PageLike pageLike);

        Task<PageLike> SearchAsync(string pageName, int userId);

        Task<long> CountAsync(string pageName);

        Task DeleteAsync(PageLike pageLike);
    }
}
