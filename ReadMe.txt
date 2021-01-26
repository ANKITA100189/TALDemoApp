Tools used:
1. VS 2019
2. .NET MVC solution.
3. Solution has 4 projects - TALDemo(UI), DataLibrary(BusinessLogic and DataAccess), DemoDB (SQL DB) and TALDemoTest (Test Project)

Data Setup

1. Execute the script : Insert Scripts.sql to insert master data and member details in the tables.

Assumptions
1. Person trying to calculate the premium is already a member and will have a Member ID which will be used for calculations.
2. Details entered by user is vaidated against the data in Member table.
3. If not match found then an appropriate message is shown to the user.