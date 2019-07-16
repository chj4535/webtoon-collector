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
            string ttest = "11233";
            return crawling.GetWebtoonTitle(titleId);
        }

        public void DownLoadNaverWebtoonImgList(ComicInfo comicInfo)
        {
            crawling.DownLoadNaverWebtoonImgList(comicInfo);
        }

        public void Test(TestEvent testevnet, string testValue)
        {
            testevnet.startevent(testValue);
        }
    }
}
