using Americanas.Web.Elements;
using ATF.Web.Elements;
using ATF.Web.Elements.Containers;
using BoDi;
using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Americanas.Web.Pages
{
    [Binding]
    public class LandingPage : DefaultHeaderPage
    {
        private ContentTop1 contentTop => new ContentTop1(By.XPath("//div[@data-position='contenttop1']"), "Os Mais Vendidos de Hoje");

        public LandingPage(IObjectContainer objectContainer) : base(objectContainer)
        {
        }

        public ContentTop1 ContentTop => contentTop;

        public override IList<IKWebElement> Fields()
        {
            List<IKWebElement> fields = (List<IKWebElement>)base.Fields();
            fields.AddRange(ContentTop.Fields());
            return fields;
        }
    }

    public class ContentTop1 : KElementPanel, IElementPanel
    {

        public IList<ContentItem> ContentItems()
        {
            List<ContentItem> items = new List<ContentItem>();
            IEnumerator<IWebElement> enumerator = FindElements(By.XPath(".//div[contains(@class,'ProductContainer')]")).GetEnumerator();
            while (enumerator.MoveNext())
            {
                IWebElement item = enumerator.Current;
                items.Add(new ContentItem(item, "Mais vendido"));
            }

            return items;
        }

        public ContentTop1(By by, string name) : base(by, name)
        {
        }

        public override IList<IKWebElement> Fields() => ((List<IKWebElement>)ContentItems());
    }


}
