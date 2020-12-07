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

        [Given(@"I on Proceed to Checkout Button in Cart Summary")]
        public void GivenIOnProceedToCheckoutButtonInCartSummary()
        {
            ClickProceedToCheckout();
        }




    }
}
