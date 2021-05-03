Feature: ToDoList
    Select first two items in the ToDoList
    Enter a new item in the ToDoList
    Add the new item to the list
 
@ToDoList
Scenario: Add items to the ToDoList
    Given that I am on the LambdaTest Sample app
    Then select the first item
    Then select the second item
    Then find the text box to enter the new value
    Then click the Submit button
    And  verify whether the item is added to the list
    Then close the browser instance