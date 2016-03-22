using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDontTuch.Models;
using HtmlAgilityPack;
using System.Threading;
using System.Threading.Tasks;

namespace WebDontTuch.Controllers
{
    public class HomeController : Controller
    {
        private IParser parser;

        public HomeController(IParser prs)
        {
            parser = prs;
        }

        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(string msg)
        {
            Message ms = new Message()
            {
                Content = msg
            };

            await parser.GetReferances(ms);
            
            return PartialView("Message", ms);
        }

       
	}
}