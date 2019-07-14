using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using webtoon_collector.Model.ClassCollect;

namespace webtoon_collector.Model
{
    public class MainModelPage
    {
        Crawling crawling = new Crawling();

        public ComicInfo GetWebtoonTitle(string titleId)
        {
            return crawling.GetWebtoonTitle(titleId);
        }

        public void DownLoadNaverWebtoonImgList(ComicInfo comicInfo)
        {
            crawling.DownLoadNaverWebtoonImgList(comicInfo);
        }

    }
}
