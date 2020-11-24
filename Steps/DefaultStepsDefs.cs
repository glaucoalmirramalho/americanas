using Americanas.Web;
using Americanas.Web.Pages;
using ATF.Drivers;
using ATF.Web.Pages;
using BoDi;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Americanas.Steps
{
    [Binding]
    public class DefaultStepsDefs : ATF.Steps.DefaultStepsDefs
    {
        LandingPage LandingPage;

        public DefaultStepsDefs(LandingPage landingPage) => LandingPage = landingPage;


        public DefaultStepsDefs(IObjectContainer objectContainer) => _objectContainer = objectContainer;

        public override IPageObject PageObject => (KWebDriver.Instance.TryFindElement(By.XPath("//h2[@class='page-title']")) == null)
                ? PageByName("Inicial")
                : PageByDisplayName(currentPageName);

        private string currentPageName => KWebDriver.Instance.FindElement(By.XPath("//h2[@class='page-title']")).Text;

        public override IDictionary<Type, PageObjectRegister> PageObjectList => new Dictionary<Type, PageObjectRegister>
            {
            { typeof(LandingPage), new PageObjectRegister("Inicial", "Inicial") },
            { typeof(BasketPage), new PageObjectRegister("Cesta de Compras", "Cesta de Compras") },
            };

    }


}
