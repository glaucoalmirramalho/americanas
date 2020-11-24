using Americanas.Web.Pages;
using BoDi;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace Americanas.Steps
{
    [Binding]
    public class LandingPageSteps
    {
        IObjectContainer ObjectContainer;
        LandingPageStepsDefs LandingPageStepsDefs;

        public LandingPageSteps(IObjectContainer objectContainer, LandingPageStepsDefs landingPageStepsDefs)
        {
            ObjectContainer = objectContainer;
            LandingPageStepsDefs = landingPageStepsDefs;
        }

        [When(@"eu adiciono um ítem do Painel '(.*)' na Cesta de Compras")]
        public void QuandoEuAdicionoUmItemDoPainelNoCestaDeCompras(string panel)
        {
            LandingPageStepsDefs.GetAnyItemFromPanel(panel);
        }

    }
}
