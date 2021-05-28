ASSIGNMENT: "Using class composition":

This assignment involves creating an app that generates different cost-reports for a company, based on single employee events:

-New employments
-Wage raises (individual or for the whole company)
-Resignments/permissions
-Step-ups-or-downs from manager to non-manager or vice versa (constant wage++ for being manager)
-Step-ups-or-downs in position percentage (affects employee cost, but not salary)

These events are passed to the app as a CSV-file (comma-seperated version of an excel-file - see classes for details on format)

The reports are given per department, per departments' team, etc. This means that organizational changes, such as
employees changing teams (sent in as an event) will have to be accounted for, before generating cost reports. There are 
also a wide variety of reports given, in a quite nested manner, for instance: Every employee's cost in two specific
teams, under a specific department. The "real" assignment here, is creating a class structure (composition) such that
reporting should be relatively easy, e.g. a simple foreach loop over the department objects to print the total cost for each department.
To get the cost per department, and then by team, a "simple" nested foreach loop is in order. 

The app's domain model is presented in "InitialDataGenerator.cs" - which constitutes the basis before any textfiles
(with events) are processed. Every event from subsequent textfiles must perfectly adhere to this class structure.

There are no explicit events relating to organizational additions, like new departments and teams. These are implied
through employment events, meaning that any new entry regarding a department or team, could be a potential
"organizational increase". This leads to a lot of searching in lists, and some tactical choices are made in order
to reduce searching, such as coupling the event-data to each relevant employee (EventRecord).
