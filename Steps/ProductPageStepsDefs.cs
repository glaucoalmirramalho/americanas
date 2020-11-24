using Americanas.Model;
using Americanas.Web.Pages;
using ATF.Model;
using TechTalk.SpecFlow;

namespace Americanas.Steps
{
    [Binding]
    public class ProductPageStepsDefs
    {
        ProductPage ProductPage;
        Datamass Datamass;

        public ProductPageStepsDefs(ProductPage productPage, Datamass datamass)
        {
            ProductPage = productPage;
            Datamass = datamass;
        }

        public void Open() 
        {
            ProductPage.Open();
            ATF.Web.Elements.ITextElement element = ProductPage.ProductContainer.ProductInfo.Title;
            string value = element.Value;
            string title = value.Split("\r\n")[2];
            Product product = new Product { Title = title };
            Datamass.Objects().Add("Produto", product);
        }

        public void AddToBasket() 
        { 
            ProductPage.ProductContainer.ProductOffer.Buy.Click();
        }
    }
}