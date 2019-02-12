using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace LikesApp.Infrastructure
{
    public static class ApiControllerExtensions
    {
        public static int GetCurrentUserId(this ApiController controller)
        {
            return HttpContext.Current.User.Identity.GetUserId<int>();
        }
    }
}
