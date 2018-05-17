using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer.EfCode;
using ServiceLayer.BookServices;
using ServiceLayer.BookServices.Concrete;

namespace Ef6BookApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(SortFilterPageOptions options)
        {
            var listService =
                new ListBooksService(new EfCoreContext());

            var bookList = listService     
                .SortFilterPage(options)
                .ToList();

            return View(new BookListCombinedDto
                (options, bookList));
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