@Calculator
Feature: Calculator
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@Add
@Ignore
Scenario: Verify add works correctly
	Given I entered number 10
	When I'm adding 11
	Then result should be equal to 21

@Minus
Scenario: Verify minus works correctly
	Given I entered number 125
	When I'm substracting 34
	Then result should be equal to 91

@Multiply
Scenario: Verify multiplication works correctly
	Given I entered number 10
	When I'm multiplying by 10
	Then result should be equal to 100
