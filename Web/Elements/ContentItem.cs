using ATF.Web.Elements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Americanas.Web.Elements
{
    public class ContentItem : Button, IButton
    {
        string title => FindElement(By.XPath(".//div[contains(@class,'src__Text')]")).Text;
        public string Title => title;

        string price => FindElement(By.XPath(".//div[contains(@class,'src__Price')]")).Text;
        public string Price => price;

        public ContentItem(By by, string name) : base(by, name)
        {

        }

        public ContentItem(IWebElement element, string name) : base(element, name) { }
    }
}
