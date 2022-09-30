Feature: TFL - Journey Planner Tests

Scenario Outline: To verify that a valid journey can be planned using the widget
Given the user navigated to TFL website
And user enters valid <from> and <to> values
When user clicks the Search button
Then user should be presented with valid results

Examples:
| from			| to		|
| Newbury Park	| Euston 	|

Scenario: To verify that the widget is unable to provide results when an invalid journey is planned

Given the user navigated to TFL website
And user enters invalid from and to values
When user clicks the Search button
Then user should be presented with valid error message

Scenario: To verify that the widget is unable to plan a journey if no locations are entered into the widget

Given the user navigated to TFL website
And user doesn't enter any values
When user clicks the Search button
Then user should be presented with mandatory field error message

Scenario Outline: To verify change time link on the journey planner displays “Arriving” option and plan a journey based on arrival time

Given the user navigated to TFL website
And user enters valid <from> and <to> values
And user selects Arriving option and enters valid <date> and <time>
When user clicks the Search button
Then user should be presented with valid results

Examples:
| from         | to     | date     | time  |
| Newbury Park | Euston | Tomorrow | 12:00 |

Scenario Outline: On the Journey results page, verify that a journey can be amended by using the “Edit Journey” button

Given the user navigated to TFL website
And user enters valid <from> and <to> values
When user clicks the Search button
And on the results page user clicks Edit Journey button
And user enters updated <edited_from> and <edited_to> values
And user clicks the Update journey button
Then user should be presented with valid results

Examples:
| from			| to		| edited_from	| edited_to	|
| Newbury Park	| Euston	| Ilford		| Romford	|

#Scenario Outline: To verify that the “Recents” tab on the widget displays a list of recently planned journeys
#
#Given the user navigated to TFL website
#And user enters valid <from> and <to> values
#When user clicks the Search button
#Then user should be presented with valid results
#When user goes back to main page and clicks the Recents button
#Then user should be presented with previous journeys <from> and <to>
#
#Examples:
#| from			| to		|
#| Newbury Park	| Euston	|
#
