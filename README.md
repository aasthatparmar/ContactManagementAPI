# ContactManagementAPI

This project implements basic CRUD operations to manage user data including their first name, last name, and email address. It allows users to:

Create: Add new user entries with their details.
Read: View existing user information.
Update: Modify user details such as first name, last name, or email.
Delete: Remove user records from the database.
The application provides a straightforward interface to interact with user data, ensuring efficient management and manipulation of user information.

Node Version used: 20.14.0
NPM version: 10.7.0
Angular CLI version:  CLI: 18.0.4
.Net version: 8.0

Table of Contents

Installation
Usage
Features

Installation

Install Node (if not already installed):

to check version of Node,npm,angular use command -> ng version

Install Angular CLI (if not already installed):

npm install -g @angular/cli

Install Bootstrap:

npm install bootstrap

Install Angular Material:

ng add @angular/material


Usage

To begin using the Contact Management Project, you need to start the API first.
After starting the API, go to the angular and,

- run 'npm install' in terminal to install all required dependencies.
- run 'ng serve' in terminal to start the angular application.
- use http://localhost:4200/ to access the frontend.

Features

Create:Add new user data with fields like first name, last name, and email address.

Read:View a list of all users stored in the database.
View detailed information of a specific user by their unique identifier (e.g., ID).

Update:Modify existing user information such as first name, last name, or email address.

Delete:Remove user records from the database based on their unique identifier.

Sorting:Allow users to sort the list of users by different attributes such as first name, last name, or email address in ascending or descending order.

Searching:Provide a search functionality to quickly find users based on keywords entered by the user. The search can be performed on fields like first name, last name, or email address.

Pagination:Display a limited number of user records per page to improve performance and user experience.
Enable navigation through pages (e.g., next page, previous page) to view additional user records.

These features collectively enhance the usability and functionality of your CRUD application, providing users with efficient ways to manage and interact with user data.
