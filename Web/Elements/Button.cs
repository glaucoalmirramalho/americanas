using ATF.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Americanas.Web.Elements
{
    public class Button : ATF.Web.Elements.Button
    {
        public Button(By by, string name) : base(by, name)
        {
        }

        public Button(IWebElement element, string name) : base(element, name)
        {
        }

        public override void Click() 
        {
            SaveArtifacts($"O botão '{Name}' é pressionado.");
            KWebDriver.Instance.ExecuteScript("arguments[0].click();", _webElement);
            
        }
    }
}
