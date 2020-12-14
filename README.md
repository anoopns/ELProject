# ELProject
How to Run this project
-You have all the latest code in the Master. Pull from the master and build the project

How the solution is structured
-Solution has 3 projects
EL - consists Page classes for Computer Add Applicaton
Class Pages helps to initialize all pages. 
All class members are threadsafe to help to implement parrallel test execution if required.

EL Tests - connsists Test classes for both Computer Add  & Alert applications.
Class BasTest initializes and teardowns driver instance for each test run 

Framework - consists classes used by the framework.
The Framework uses a factory class to initialize the selenium webdriver. Current project only support Chrome. 


Total Time taken to complete the project:
Test case writing - 1 to 1.5 hours
Manual test case location - https://github.com/anoopns/ELProject/blob/master/Manual%20Tests.xlsx

FrameWork & Test case automation:
Framework - around 4 hours
Test case writing - aroun 2 hours



