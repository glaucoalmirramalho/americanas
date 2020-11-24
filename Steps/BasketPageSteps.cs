using Americanas.Model;
using Americanas.Web.Elements;
using ATF.Model;
using NUnit.Framework;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Americanas.Steps
{
    [Binding]
    public class BasketPageSteps
    {
        private readonly BasketPageStepsDefs BasketPageStepsDefs;
        private readonly Datamass Datamass;

        public BasketPageSteps(BasketPageStepsDefs basketPageStepsDefs, Datamass datamass)
        {
            BasketPageStepsDefs = basketPageStepsDefs;
            Datamass = datamass;
        }

        [Then(@"o nome do ítem adicionado na Cesta de Compras será o mesmo escolhido anteriormente")]
        public void EntaoONomeDoItemAdicionadoNaCestaDeComprasSeraOMesmoEscolhidoAnteriormente()
        {
            bool itemFound = BasketPageStepsDefs.FindProduct();
            Assert.True(itemFound);
        }

        [When(@"eu excluo o ítem adicionado anteriormente")]
        public void EuExcluoOItemAdicionadoAnteriormente()
        {
            BasketPageStepsDefs.RemoveProduct();
            
        }

        [Then(@"a Cesta de Compras estará vazia")]
        public void EntaoACestaDeComprasEstaraVazia()
        {
            int count = BasketPageStepsDefs.ProductCount();
            Assert.AreEqual(0, count);
        }


    }
}
