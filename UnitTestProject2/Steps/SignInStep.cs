using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;


namespace Trab3QP
{
    [Binding]
    class SignInStep : SignInPage
    {

        [Then(@"the sign in page will be displayed")]
        public void ThenTheSignInPageWillBeDisplayed()
        {
            ValidateSignInPage();
        }

        [Then(@"the site will be closed")]
        public void ThenTheSiteWillBeClosed()
        {
            CloseSite();
        }


    }
}
