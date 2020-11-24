using ATF.Drivers;
using ATF.Web.Elements;
using ATF.Web.Elements.Containers;
using BoDi;
using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Americanas.Web.Pages
{
    [Binding]
    public class DefaultHeaderPage : DefaultPage
    {
        private HeaderMiddle HeaderMiddle => new HeaderMiddle(By.XPath("//div[@id='header-middle']"), "Cabeçalho do Meio");

        public DefaultHeaderPage(IObjectContainer objectContainer) : base(objectContainer)
        {
        }

        public override object Value { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public override IList<IKWebElement> Fields() => HeaderMiddle.Fields();
        public override void Open() => KWebDriver.Instance.Navigate().GoToUrl($"{ROOT}");
    }

    public class HeaderMiddle : KElementPanel, IElementPanel
    {
        private IButton Basket => new Button(By.XPath("//*[@class='crt-link']"), "Cesta");

        public HeaderMiddle(By by, string name) : base(by, name)
        {
        }

        public override IList<IKWebElement> Fields() => new List<IKWebElement> { Basket };
    }
}