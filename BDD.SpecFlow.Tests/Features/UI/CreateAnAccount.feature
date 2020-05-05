@UI
@Authentication
@CreateAnAccount
Feature: CreateAnAccount

Background: Go to authentication page
	Given I have navigated to My Account page

Scenario: Verify user is able to create a new account
	Given I went to create an account page with adfas@zcjvjzxl.com email
	When I register the following information
	| Field      | Value      |
	| Title      | Mr.        |
	| First Name | John       |
	| Last Name  | Doe        |
	| Password   | Password@2 |
	Then exceptions should be shown