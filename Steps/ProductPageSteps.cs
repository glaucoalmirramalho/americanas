using BoDi;
using TechTalk.SpecFlow;

namespace Americanas.Steps
{
    [Binding]
    public class ProductPageSteps
    {
        private readonly IObjectContainer ObjectContainer;
        private readonly ProductPageStepsDefs ProductPageStepsDefs;
        private readonly DefaultStepsDefs DefaultStepsDefs;

        public ProductPageSteps(IObjectContainer objectContainer, ProductPageStepsDefs productPageStepsDefs, DefaultStepsDefs defaultStepsDefs)
        {
            ObjectContainer = objectContainer;
            ProductPageStepsDefs = productPageStepsDefs;
            DefaultStepsDefs = defaultStepsDefs;
        }

        [Given("que eu acesse um Produto")]
        public void EuAcessoUmProduto() 
        { 
            ProductPageStepsDefs.Open(); 
        }

        [When("eu adiciono o Produto na Cesta")]
        public void EuAdicionoProdutoNaCesta() => ProductPageStepsDefs.AddToBasket();

        
    }
}
