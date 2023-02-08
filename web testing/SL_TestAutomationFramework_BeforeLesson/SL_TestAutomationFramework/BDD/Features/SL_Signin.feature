Feature: SL_Signin

As a Customer, I want to be able to enter a valid username and password, so i can sign in

@Signin
@HappyPath
Scenario: Login with a valid email and password
	Given I am on the home page
	And I enter a valid username
	And I enter a valid password
	When I click the login button
	Then I should land on the inventory page

@Signin
@Sad
Scenario: Login with valid email and invalid password 
Given I am on the home page 
And I enter a valid username
And I enter an invalid password of "<passwords>"
When I click the login button 
Then I should see an error message that contains "Epic sadface"
Examples: 
| Passwords |
| wrong     |
| 12345     |
| Nishy     |

@Signin
@Sad
Scenario: Invalid e-mail and password
	Given I am on the home page
	And I have the following credentials:
		| Username        | Password |
		| fakeusername | nish     |
	And enter these credentials
	When I click the login button
	Then I should see an error message that contains "Epic sadface"