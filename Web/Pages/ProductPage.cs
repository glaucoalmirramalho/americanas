using ATF.Drivers;
using ATF.Web.Elements;
using ATF.Web.Elements.Containers;
using BoDi;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Americanas.Web.Pages
{
    [Binding]
    public class ProductPage : DefaultHeaderPage
    {
        public ProductPage(IObjectContainer objectContainer) : base(objectContainer)
        {
        }

        private ProductContainer productContainer => new ProductContainer(By.Id("root"), "Container do Produto");
        public ProductContainer ProductContainer => productContainer;

        public override IList<IKWebElement> Fields() 
        {
            List<IKWebElement> fields = base.Fields().ToList();
            fields.AddRange(ProductContainer.Fields());
            return fields;
        }
        public override void Open() 
        {
            KWebDriver.Instance.Url = "https://www.americanas.com.br/produto/417204914?chave=acproduct";
            KWebDriver.Instance.Navigate();
        }
    }

    public class ProductContainer : KElementPanel
    {
        private ProductInfo productInfo => new ProductInfo(By.XPath(".//div[contains(@class,'src__ProductInfo')]"), "Informações do Produto");
        public ProductInfo ProductInfo => productInfo;
        private ProductOffer productOffer => new ProductOffer(By.XPath(".//div[contains(@class,'src__ProductOffer')]"), "Informações do Produto");
        public ProductOffer ProductOffer => productOffer;
        public ProductContainer(By by, string name) : base(by, name)
        {
        }

        public override IList<IKWebElement> Fields()
        {
            List<IKWebElement> fields = new List<IKWebElement>();
            fields.AddRange(ProductInfo.Fields());
            fields.AddRange(ProductOffer.Fields());
            return fields;
        }
    }

    public class ProductInfo : KElementPanel
    {
        private ITextElement title => new TextElement(By.XPath(".//div[contains(@class,'ProductInfo')]"), "Título");
        public ITextElement Title => title;
        public ProductInfo(By by, string name) : base(by, name)
        {
        }

        public override IList<IKWebElement> Fields() => new List<IKWebElement> { Title };
    }

    public class ProductOffer : KElementPanel
    {
        private IButton buy => new Elements.Button(By.XPath(".//div[contains(@class,'BuyButtonWrapper')]//a"), "Comprar");
        public IButton Buy => buy;
        public ProductOffer(By by, string name) : base(by, name)
        {
        }

        public override IList<IKWebElement> Fields() => new List<IKWebElement> { Buy };
    }
}
