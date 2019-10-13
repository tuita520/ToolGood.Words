﻿using PetaTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolGood.Words.Test
{
    [TestFixture]
    public class IssuesTest
    {
        /// <summary>
        /// https://github.com/toolgood/ToolGood.Words/issues/17
        /// </summary>
        [Test]
        public void IssuesTest_17()
        {
            var illegalWordsSearch = new IllegalWordsSearch();
            string s = "中国|zg人|abc";
            illegalWordsSearch.SetKeywords(s.Split('|'));
            var str = illegalWordsSearch.Replace("我是中美国人厉害中国完美ａｂｃddb好的", '*');

            Assert.AreEqual("我是中美国人厉害**完美***ddb好的", str);
        }


        /// <summary>
        /// https://github.com/toolgood/ToolGood.Words/issues/20
        /// </summary>
        [Test]
        public void IssuesTest_20()
        {
            string text = "A10021003吃饭";
            var keywords = new string[] { "1", "A", "2", "0", "吃" };
            var iws = new IllegalWordsSearch();
            var ss = new StringSearch();
            var sse = new StringSearchEx();

            iws.SetKeywords(keywords);
            iws.UseIgnoreCase = true;
            iws.UseDBCcaseConverter = true;
            var iwsFirst = iws.FindFirst(text);
            var iwsAll = iws.FindAll(text);
            Assert.AreEqual(9, iwsAll.Count);

            ss.SetKeywords(keywords);
            var ssFirst = ss.FindFirst(text);
            var ssAll = ss.FindAll(text);
            Assert.AreEqual(9, ssAll.Count);

            sse.SetKeywords(keywords);
            var sseFirst = sse.FindFirst(text);
            var sseAll = sse.FindAll(text);
            Assert.AreEqual(9, sseAll.Count);

        }

    }
}