@chrome
Feature:Automate The Online Shopping site Flipkart

Scenario: Automate Flipkart website homepage
	Given I launch the  flipkart website
	When The site opens A popup window that should be  handle 
	And I Check for the Tabs on the flipkart site
	Then Verify the Tab with Title of the tabs on the flipkart site 
	| Title              |
	| Mobiles            |
	| Fashion            |
	| Electronics        |
	| Home               |
	| Travel             |
	| Appliances         |
	| Beauty,Toys & more |
	| Grocery            |
	
@Airconditioner
Scenario: Select product from Electronics Section of Flipkart
Given I Click on the electronics section
And  I select the  air conditioner of type 'AirConditioner' 
| AirConditioner |
| Split ACs       |
Then I Verify the Acs result displayed is more than 4
When I click on Any Result Item
Then I Verify "BeforePrice" and AfterPrice
| BeforePrice |
| ₹36,499     |


