# NeighborhoodFinder Web Application

## Table of Contents

- [Introduction](#introduction)
- [Project Structure](#project-structure)
- [Technologies](#technologies)
- [Features](#features)



## Introduction

NeighborhoodFinder is an ASP.NET web application designed to help users find their ideal neighborhood when moving to a new city. Powered by ChatGPT!

## Project Structure

The project follows the MVC (Model-View-Controller) pattern and is organized as follows:

- **Controllers**: This directory contains all the controller classes responsible for handling user interactions.
  - `HomeController.cs`: Handles the main/home functionality and routes.
  - `SubmissioNController.cs`: Handles submissions and results. 
  - [Not In Use]`OpenAiController.cs`: Manages interactions with the OpenAI API. Details: Kept as an example for Web API practice.
  
  
- **Models**: Includes classes that represent the data structures.
  - `Submission.cs`: Represents a user's submission for the database.
  - `SubmissionViewModel.cs`: Represents a user's submission pre-database. 
  - `User.cs`: Represents the application's user model.

- **Views**: Contains the Razor views for the different controllers.
  - `Home`: Views related to the home page and main functionality.
  - `Account`: Views for login and account creation.
  - `Submission`: Results View after valid submission, contains partial view for form. 

- **Data**: Houses the Entity Framework data context and migrations.
  - `ApplicationDbContext.cs`: The main data context class.

- **Services**: Contains any additional services like OpenAI API interaction.
  - `OpenAiService.cs`: Implementation of the OpenAI API service.



## Technologies

- Language: C#
- Framework: ASP.NET
- Database: SQLite with Entity Framework, SQL when deployed to azure 
- Cloud: Azure
- Others: OpenAI API, Identity for authentication

## Features

- Ideal Neighborhood Finder
- User Authentication
- User Submissions



