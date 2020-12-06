using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;


namespace Trab3QP
{
    [Binding]
    class ProductStep:ProductPage
    {

        [Then(@"the product page will be displayed")]
        public void ThenTheProductPageWillBeDisplayed()
        {
            ValidateProductPage();
        }

        [Given(@"I click on Add To Cart Button")]
        public void GivenIClickOnAddToCartButton()
        {
            ClickAddToCart();
        }

        [When(@"I click on Proceed to Checkout Button in Product Page")]
        public void WhenIClickOnProceedToCheckoutButtonInProductPage()
        {
            ClickProceedToCheckout();
        }

    }
}
