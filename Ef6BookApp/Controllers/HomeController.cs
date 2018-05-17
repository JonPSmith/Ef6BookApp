using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var context = new EfCoreContext();
            context.Database.Log = message => Trace.Write(message);
            var listService =
                new ListBooksService(context);

            var bookList = listService     
                .SortFilterPage(options)
                .ToList();

            return View(new BookListCombinedDto
                (options, bookList));
        }

        [HttpGet]
        public JsonResult GetFilterSearchContent    
            (SortFilterPageOptions options)         
        {
            var service = new                       
                BookFilterDropdownService(new EfCoreContext());

            return Json(service.GetFilterDropDownValues(    
                        options.FilterBy));            
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