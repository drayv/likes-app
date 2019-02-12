using System;
using System.Threading.Tasks;
using LikesApp.Core.Entities;
using LikesApp.EntityFramework.Repositories.PageLikes;

namespace LikesApp.Core.PageLikes
{
    public class PageLikesManager : IPageLikesManager
    {
        private readonly IPageLikesRepository _pageLikesRepository;

        public PageLikesManager(IPageLikesRepository pageLikesRepository)
        {
            _pageLikesRepository = pageLikesRepository;
        }

        public async Task<long> GetLikesCountAsync(string pageName)
        {
            return await _pageLikesRepository.CountAsync(pageName);
        }

        public async Task<bool> IsLikedByUserAsync(string pageName, int userId)
        {
            var pageLike = await _pageLikesRepository.SearchAsync(pageName, userId);

            return (pageLike != null);
        }

        public async Task LikeAsync(string pageName, int userId)
        {
            var pageLike = await _pageLikesRepository.SearchAsync(pageName, userId);

            if (pageLike == null)
            {
                await _pageLikesRepository.CreateAsync(new PageLike
                {
                    Page = pageName,
                    UserId = userId
                });
            }
            else
            {
                throw new Exception("You cannot like the same page multiple times.");
            }
        }

        public async Task UnlikeAsync(string pageName, int userId)
        {
            var pageLike = await _pageLikesRepository.SearchAsync(pageName, userId);

            if (pageLike != null)
            {
                await _pageLikesRepository.DeleteAsync(pageLike);
            }
            else
            {
                throw new Exception("You cannot unlike the same page multiple times.");
            }
        }
    }
}
