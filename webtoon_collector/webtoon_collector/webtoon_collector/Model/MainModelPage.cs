using System;
using System.Collections.Generic;
using System.Text;

namespace webtoon_collector.Model
{
    public class MainModelPage
    {
        Crawling crawling = new Crawling();

        public string GetWebtoonTitle(string titleId)
        {
            return crawling.GetWebtoonTitle(titleId);
        }
    }
}
