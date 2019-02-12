using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using LikesApp.Core.Entities;

namespace LikesApp.EntityFramework.Repositories.PageLikes
{
    public class PageLikesRepository : IPageLikesRepository
    {
        private readonly LikesDbContext _likesDbContext;

        public PageLikesRepository(LikesDbContext likesDbContext)
        {
            _likesDbContext = likesDbContext;
        }

        public async Task CreateAsync(PageLike pageLike)
        {
            _likesDbContext.PageLikes.Add(pageLike);

            await _likesDbContext.SaveChangesAsync();
        }

        public async Task<PageLike> SearchAsync(string pageName, int userId)
        {
            return await _likesDbContext.PageLikes.Where(l => l.Page == pageName && l.UserId == userId).FirstOrDefaultAsync();
        }

        public async Task<long> CountAsync(string pageName)
        {
            return await _likesDbContext.PageLikes.Where(l => l.Page == pageName).LongCountAsync();
        }

        public async Task DeleteAsync(PageLike pageLike)
        {
            _likesDbContext.PageLikes.Attach(pageLike);
            _likesDbContext.PageLikes.Remove(pageLike);

            await _likesDbContext.SaveChangesAsync();
        }
    }
}
