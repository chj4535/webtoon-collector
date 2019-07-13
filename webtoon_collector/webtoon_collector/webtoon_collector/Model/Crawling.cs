using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using webtoon_collector.Model.ClassCollect;

namespace webtoon_collector.Model
{
    public class Crawling
    {
        public ComicInfo GetWebtoonTitle(string titleId)
        {
            ComicInfo comicInfo = new ComicInfo();
            string url = "https://comic.naver.com/webtoon/list.nhn?titleId=" + titleId;

            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument document = htmlWeb.Load(url);
            HtmlNode comicImgnode = document.DocumentNode.SelectSingleNode("//div[@class='thumb']/a/img");
            string autor = document.DocumentNode.SelectSingleNode("//div[@class='detail']/h2/span").InnerText;
            autor = Regex.Replace(autor, @"\s|\n|\r|\t", "");
            comicInfo.TitleImgUrl = comicImgnode.Attributes["src"].Value;
            comicInfo.Title = comicImgnode.Attributes["title"].Value;
            comicInfo.Autor = autor;
            comicInfo.TitleId = titleId;
            return comicInfo;
        }

        public List<Stream> GetNaverWebtoonImgList(ComicInfo comicInfo)
        {
            int start = Int32.Parse(comicInfo.StartEpisode);
            int end = Int32.Parse(comicInfo.StartEpisode);
            List<Stream> imgList = new List<Stream>();
            for (int i = start; i <= end; i++)
            {
                string url = "https://comic.naver.com/webtoon/detail.nhn?titleId=" + comicInfo.TitleId + "&no=" + i;
                HtmlWeb htmlWeb = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument document = htmlWeb.Load(url);
                HtmlNodeCollection comicImgnodes = document.DocumentNode.SelectNodes("//div[@class='wt_viewer']/img");
                foreach (HtmlNode comicImgnode in comicImgnodes)
                {
                    string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "temp.jpg");
                    string comicImg = comicImgnode.Attributes["src"].Value;
                    HttpWebRequest httpWebrequest = (HttpWebRequest)WebRequest.Create(comicImg);
                    httpWebrequest.Referer = "http://www.naver.com";
                    HttpWebResponse httpWebresponse = (HttpWebResponse)httpWebrequest.GetResponse();
                    Stream inputStream = httpWebresponse.GetResponseStream();


                    byte[] buffer = ReadFully(inputStream);
                    File.WriteAllBytes(fileName, buffer);
                }
            }
            return imgList;
        }

        public static byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}
