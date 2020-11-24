using Americanas.Model;
using Americanas.Web;
using Americanas.Web.Elements;
using ATF.Model;
using BoDi;
using System;
using System.Collections.Generic;

namespace Americanas.Steps
{
    public class BasketPageStepsDefs
    {
        private readonly IObjectContainer ObjectContainer;
        private readonly BasketPage BasketPage;
        private readonly Datamass Datamass;

        public BasketPageStepsDefs(IObjectContainer objectContainer, BasketPage basketPage, Datamass datamass)
        {
            ObjectContainer = objectContainer;
            BasketPage = basketPage;
            Datamass = datamass;
        }

        public IList<BasketItemWebElement> Items() => BasketPage.BasketProductList.BasketItemWebElements;
        internal bool FindProduct() 
        {
            Product product = (Product)Datamass.Objects()["Produto"];
            IEnumerator<BasketItemWebElement> enumerator = Items().GetEnumerator();
            bool itemFound = false;
            while (enumerator.MoveNext() || !itemFound)
            {
                BasketItemWebElement basketItem = enumerator.Current;
                itemFound = basketItem.Title.Value.Equals(product.Title);
            }
            return itemFound;
        }

        internal int ProductCount() 
        {
            System.Threading.Thread.Sleep(2000);
            int count = 0;
            try
            {
                count = Items().Count;
            }
            catch (OpenQA.Selenium.NoSuchElementException) { }
            return count;
        }

        internal void RemoveProduct() 
        {
            Product product = (Product)Datamass.Objects()["Produto"];
            IEnumerator<BasketItemWebElement> enumerator = Items().GetEnumerator();
            bool itemFound = false;
            BasketItemWebElement basketItem = default;
            while (enumerator.MoveNext() || !itemFound)
            {
                basketItem = enumerator.Current;
                itemFound = basketItem.Title.Value.Equals(product.Title);
            }
            basketItem.Remove.Click();
        }
    }
}