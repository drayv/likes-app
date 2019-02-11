namespace LikesApp.Core.Entities
{
    public class PageLike : Entity<long>
    {
        public string UserId { get; set; }

        public string Page { get; set; }
    }
}
