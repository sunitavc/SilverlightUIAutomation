Feature: Sanity
	In order to demonstrate the power of Specflow
	As a tester
	I want to use the System Under Test

@mytag
Scenario: Interact with elements on the Visual Binding page
	Given I am on the Welcome page
	When I interact with the checkbox on the Visual Binding Page
	Then the checkbox should recieve my input
