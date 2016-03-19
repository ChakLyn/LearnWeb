using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDontTuch.Models;
using HtmlAgilityPack;
using System.Threading;
namespace WebDontTuch.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string msg)
        {
            Message ms = new Message(){
                Content = msg
            };

            AmazonParser parser= new AmazonParser();
            parser.GetReferances(ms);
            
            return PartialView("Message", ms);
        }

        public interface IParser 
        {
             void GetReferances(Message model);
        }
        public class AmazonParser:IParser
        {

            public void GetReferances(Message model)
            {                
                HtmlWeb web = new HtmlWeb();
                // load page for parsing
                HtmlDocument doc = new HtmlDocument();
             
                string key = model.Content.Replace(" ", "%20");
                string adress = "https://www.amazon.com/s/ref=nb_sb_noss_1?url=search-alias%3Daps&field-keywords=" + key;
              
                doc = web.Load(adress);
             
                for(int i = 0; i < 10000; i++)
                {}
              
                HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//div");
                if (nodes != null)
                {
                    foreach (HtmlNode docs in nodes)
                    {
                        try
                        {
                            var idName = docs.Attributes["id"].Value;
                            if (idName == "resultsCol")
                            {
                                HtmlNode hreff = docs;


                                model.RefList = hreff.InnerHtml;
                            }
                        }

                        catch (NullReferenceException)
                        {


                        }
                    }

                }
 


            }

        }
	}
}