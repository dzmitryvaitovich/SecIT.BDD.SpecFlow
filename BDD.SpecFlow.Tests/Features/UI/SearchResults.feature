@UI
@SearchResults
Feature: SearchResults

Scenario Outline: Verify search results
	When I search for <searchText>
	Then <expectedCount> items should be displayed on the Search Result page

	Examples:
	| searchText  | expectedCount |
	| T-Shirt     | 1             |
	| sGfgzfgsgzd | 0             |
