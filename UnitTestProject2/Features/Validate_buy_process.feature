Feature:Validate buy process

Scenario: 01_Validate access the site
	Given I go to "http://www.automationpractice.com"
	Then the site will be displayed

Scenario: 02_Validate the choose of a product
	Given I click on product
	Then the product page will be displayed	

Scenario: 03_Validate go to cart sumamry
	Given I click on Add To Cart Button
	When I click on Proceed to Checkout Button in Product Page
	Then the cart summary page will be displayed

Scenario: 04_Validate the sign in page
	Given I on Proceed to Checkout Button in Cart Summary
	Then the sign in page will be displayed
	And the site will be closed
