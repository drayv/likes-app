using System.Web.Mvc;
using LikesApp.Application.PageLikes;

namespace LikesApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPageLikesService _pageLikesService;

        public HomeController(IPageLikesService pageLikesService)
        {
            _pageLikesService = pageLikesService;
        }

        public ActionResult Index()
        {
            _pageLikesService.Test();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
