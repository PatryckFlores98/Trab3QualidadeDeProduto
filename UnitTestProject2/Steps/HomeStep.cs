using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;


namespace Trab3QP
{
    [Binding]
    class HomeStep : HomePage
    {
      
        [Given(@"I go to ""(.*)""")]
        public void GivenIGoTo(string site)
        {
            GoToSite(site);
        }

        [Then(@"the site will be displayed")]
        public void ThenTheSiteWillBeDisplayed()
        {
            ValidateHome();
        }


        [Given(@"I click on product")]
        public void GivenIClickOnProduct()
        {
            ClickOnProduct();
        }


    }
}
