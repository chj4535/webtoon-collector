using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace webtoon_collector.Model
{
    public class Crawling
    {
        public string GetWebtoonTitle(string titleId)
        {
            string url = "https://comic.naver.com/webtoon/list.nhn?titleId=" + titleId;

            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument document = htmlWeb.Load(url);
            HtmlNode bodyNode = document.DocumentNode.SelectSingleNode("//body");
            HtmlNode imgNods = document.DocumentNode.SelectSingleNode("//div[@class='detail']/h2");
            string title = imgNods.InnerText;
            title = Regex.Replace(title, @"\t|\n|\r|","");
            return null;
        }
    }
}
