using System;
using System.Collections.Generic;
using System.Text;

namespace webtoon_collector.Model
{
    public class TestEvent
    {
        public event EventHandler testevent;

        public void startevent(string testname)
        {
            if (this.testevent != null)
            {
                testevent(testname, EventArgs.Empty);
            }
        }
    }
}
