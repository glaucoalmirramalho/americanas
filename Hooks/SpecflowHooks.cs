using Americanas.Steps;
using BoDi;
using TechTalk.SpecFlow;

namespace Americanas.Hooks
{
    [Binding]
    public class SpecflowHooks
    {
        private readonly IObjectContainer _objectContainer;

        public SpecflowHooks(IObjectContainer objectContainer) => _objectContainer = objectContainer;

        [BeforeStep]
        public void StepsDefs()
        {
            if (!_objectContainer.IsRegistered<ATF.Steps.IDefaultStepsDefs>())
            {
                ATF.Steps.IDefaultStepsDefs defaultStepsDefs = new DefaultStepsDefs(_objectContainer);
                _objectContainer.RegisterInstanceAs(defaultStepsDefs);
            }
        }
    }
}
