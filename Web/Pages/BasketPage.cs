using Americanas.Web.Elements;
using ATF.Drivers;
using ATF.Web.Elements;
using ATF.Web.Elements.Containers;
using ATF.Web.Pages;
using BoDi;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Americanas.Web
{
    public class BasketPage : PageObject
    {
        public BasketPage(IObjectContainer objectContainer) : base(objectContainer)
        {
        }

        private BasketProductList basketProductList => new BasketProductList(By.XPath("//div[@class='basket-products']"), "Lista de Produtos");

        public BasketProductList BasketProductList => basketProductList;

        public override object Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override IList<IKWebElement> Fields() => basketProductList.Fields();
        public override void Open()
        {
            IWebElement webElement = KWebDriver.Instance.TryFindElement(By.XPath("//a[@href='https://sacola.americanas.com.br/#/basket']"));
            if (webElement != null)
            {
                webElement.Click();
            }
            else 
            { 
                KWebDriver.Instance.Url = "https://sacola.americanas.com.br/#/basket"; 
                KWebDriver.Instance.Navigate(); 
            }
        }
    }

    public class BasketProductList : KElementPanel, IElementPanel
    {
        private IList<BasketItemWebElement> basketItemWebElements => GetBasketItemWebElement();
        public IList<BasketItemWebElement> BasketItemWebElements => basketItemWebElements;

        private IList<BasketItemWebElement> GetBasketItemWebElement()
        {
            IList<BasketItemWebElement> basketItems = new List<BasketItemWebElement>();
            FindElements(By.XPath("//li[@class='basket-product']")).ToImmutableList().ForEach(element =>
            {
                BasketItemWebElement basketItemWebElement = new BasketItemWebElement(element);
                basketItems.Add(basketItemWebElement);
            });
            return basketItems;
        }

        public BasketProductList(By by, string name) : base(by, name)
        {
        }

        public override IList<IKWebElement> Fields() => (IList<IKWebElement>)BasketItemWebElements;
    }
}
