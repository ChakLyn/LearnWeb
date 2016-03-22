using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HtmlAgilityPack;
using System.Threading.Tasks;
using System.Net.Http;

namespace WebDontTuch.Models
{
    public class AmazonParser:IParser
    {
        public async Task GetReferances(Message model)
        {
            

            // trasform empty places with %20 for site search
            string key = model.Content.Replace(" ", "%20");
            string adress = "https://www.amazon.com/s/ref=nb_sb_noss_1?url=search-alias%3Daps&field-keywords=" + key;


            // load page for parsing
            HtmlDocument doc = new HtmlDocument();

            HttpClient client = new HttpClient();
            var html = await client.GetStringAsync(adress);
            doc.LoadHtml(html);

            //search for all div blocks     
            var result = doc.DocumentNode.SelectSingleNode("//div[@id='resultsCol']");

            model.RefList = result.InnerHtml;
            

           }

        }
 }