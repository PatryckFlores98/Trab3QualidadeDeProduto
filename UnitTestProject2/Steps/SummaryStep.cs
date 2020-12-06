using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;


namespace Trab3QP
{
    [Binding]
    class SummaryStep : SummaryPage
    {
        [Then(@"the cart summary page will be displayed")]
        public void ThenTheCartSummaryPageWillBeDisplayed()
        {
            ValidateCartSummary();
        }

      





    }
}
