using Americanas.Web.Elements;
using Americanas.Web.Pages;
using ATF.Model;
using BoDi;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Americanas.Steps
{
    [Binding]
    public class LandingPageStepsDefs
    {
        IObjectContainer ObjectContainer;
        LandingPage LandingPage;
        Datamass Datamass;

        public LandingPageStepsDefs(IObjectContainer objectContainer, LandingPage landingPage, Datamass datamass)
        {
            ObjectContainer = objectContainer;
            LandingPage = landingPage;
            Datamass = datamass;
        }

        internal void GetAnyItemFromPanel(string panel) 
        {
            int count = LandingPage.ContentTop.ContentItems().Count;
            int i = new Random().Next(0, count);
            ContentItem contentItem = LandingPage.ContentTop.ContentItems()[i];
            Datamass.Objects().Add("Ítem Para Cesta", contentItem);
        }
    }
}