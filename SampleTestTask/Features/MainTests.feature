
Feature: Main Tests

Background:
	Given I navigate to application
	And I enter username and password
	Then I should see user logged in to the application

	
Scenario: Create a new contact
	Given I navigate to contact Page
	Then I enter contact information
		| FirstName | LastName | Category            | BusinessRole |
		| test      | user     | Customers, Business | CEO          |
	Then Validate the contact information
		| FirstName | LastName | Category            | BusinessRole |
		| test      | user     | Customers, Business | CEO          |

Scenario: Run Project Profitability report
	Given I navigate to Reports AND Settings > Reports
	Then I run the Project Profitability report
	Then I verify that some results were returned

Scenario: Delete first 3 items from activity log
	Given I navigate to Reports AND Settings > Activity
	Then I select and delete the first 3 items in the table
	Then I verify that the items were deleted

  
 
