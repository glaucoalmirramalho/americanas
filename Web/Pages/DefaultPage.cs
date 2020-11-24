using ATF.Web.Pages;
using BoDi;

namespace Americanas.Web.Pages
{
    public abstract class DefaultPage : PageObject, IPageObject
    {
        protected DefaultPage(IObjectContainer objectContainer) : base(objectContainer)
        {
        }
    }
}