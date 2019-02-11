namespace LikesApp.Core.Entities
{
    public class PageLike : Entity<long>
    {
        public int UserId { get; set; }

        public string Page { get; set; }
    }
}
