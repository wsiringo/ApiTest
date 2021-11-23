# Aeroqual Cloud Developer test

This test is to create a simple API that serves data from a json file.

The JSON file is data.json, and contains a list of people, with their names and ages.

We would like you to create a RESTful API that allows you to create, update, delete, and get people.

In addition, we would like to be able to search by a person's name. The input may not always be a complete name, e.g. if the input is "hat", we expect "hat", "hatter", "that" etc to be returned.

You are free to layout the project however you wish. 

We would like to see what you would consider production quality code.

Please commit your code to a private github repository and share it with maxgruebneraeroqual.

If you cannot do that for some reason, please zip the source code and email it to the recruiter.

If you have made any design decisions that you would like to explain please add them to this file.

******************************************************************************************
Comments by applicant Wilson Siringoringo 23/11/2021
1. It is not feasible to write production grade code under the constraints of time and ad-hoc design of the application's starting point, a more realistic target is code of a "proof of concept" quality instead.
2. For portability reason, the data is stored in its original text form (as a JSON file). The working copy is stored in the same directory of the application binary files.
3. To achieve a degree of vertical separation of concerns, a data access class "PeopleRepository" is introduced. Which allows the controller class (PeopleController) to implement business logic at a higher level of abstraction.
4. No attempt has been made to secure the APIs, as there is no such requirement on the specifications
5. REST APIs are invoked as follows:
    List all persons in the repository: GET <base URI>/people
    Search persons by name: GET <base URI>/people/<search text>
    Add a new person record to the repository: POST <base URI>/people {JSON data}
    Modify existing person record: PUT <base URI>/people/<person ID> {JSON data}
    Delete existing person record: DELETE <base URI>/people/<person ID>
******************************************************************************************
