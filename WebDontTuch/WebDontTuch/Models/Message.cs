using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HtmlAgilityPack;

namespace WebDontTuch.Models
{
    public class Message
    {
        public string Name { get; set; }

        public string Content { get; set; }

        public string RefList { get; set; } 
    }
}