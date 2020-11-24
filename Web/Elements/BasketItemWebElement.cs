using Americanas.Model;
using ATF.Web.Elements;
using OpenQA.Selenium;
using System;

namespace Americanas.Web.Elements
{
    /// <summary>
    /// Webelement de um ítem adicionado ao Cesta de Compras
    /// </summary>
    public class BasketItemWebElement : KWebElement, IKWebElement
    {
        BasketProduct basketItem => GetBasketItemModel();
        public BasketProduct BasketItem => basketItem;

        ITextElement title => new TextElement(By.ClassName("basket-productTitle"), "Título");
        public ITextElement Title => title;

        ITextInputElement qty => new TextInputElement(By.XPath("//input[@name='productQuantity']"), "Quantidade");
        public ITextInputElement Qty => qty;

        ITextElement price => new TextElement(By.ClassName("basket-productTitle"), "Preço");
        public ITextElement Price => price;

        IButton remove => new Button(By.XPath("//span[contains(@class,'basket-productRemoveAct link-primary')]"), "Remover");
        public IButton Remove => remove;

        private BasketProduct GetBasketItemModel() 
        {
            string title = Title.Value;
            string qty = Qty.Value;            
            double price = double.Parse(Price.Value.Replace("R$", "").Replace(".","").Replace(",","."));
            return new BasketProduct {
                Title = title,
                Qty = qty,
                Price = price
            };            
        }

        public BasketItemWebElement(By by) : base(by, "Ítem do Cesta de Compras")
        {
            
        }

        public BasketItemWebElement(IWebElement element) : base(element, "Ítem do Cesta de Compras")
        {
        }

        public void RemoveItem()
        {
            Remove.Click();
        }

    }
}
