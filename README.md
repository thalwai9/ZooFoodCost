# Zoo Food Cost Calculator

This project calculates the total cost of feeding the animals in a zoo for a day based on provided data.

## Table of Contents

- [Overview](#overview)
- [Dependencies](#dependencies)
- [Installation](#installation)
- [Usage](#usage)
- [API Endpoints](#api-endpoints)
- [Data Files](#data-files)
- [Unit Test](#unit-test)
- [Contributing](#contributing)
- [License](#license)

## Overview

The application calculates the total cost of feeding the animals in a zoo for a day. 
It reads data from three files: `prices.txt`, `animals.csv`, and `zoo.xml`. 
Based on this data, it calculates the total cost using a dependency injection approach.

## Dependencies
- .NET Core SDK (version 6.0 or above)

## Installation

1. Clone this repository to your local machine:
   git clone (https://github.com/thalwai9/ZooFoodCost)

## Usage

The Swagger UI provides an interactive interface for exploring and testing the API. 
You can use it to make requests to the API and view the responses.

1. Build the solution:
dotnet build

2. Run the application:
dotnet run --project ZooFoodApi.API

3. The API will start running, and you can access it at https://localhost:7169/swagger/index.html by default.

## API Endpoints
GET /api/ZooCost: Calculates the total cost of feeding the animals in the zoo for a day.


## Data Files
prices.txt: Contains the prices of meat and fruit per kg.
animals.csv: Contains information about animal species, their food type, and rates.
zoo.xml: Provides information about the animals in the zoo, including their names and weights.

## Unit Tests

To run unit tests for the Zoo Food CostPerDay Test, follow these steps:

1. Navigate to the test project directory:
   cd ZooFoodCostPerDayTest.Tests

2. Run the tests:
   dotnet test

   
## Contributing
Contributions are welcome! Please feel free to open issues or pull requests for any improvements or new features.


## License
This project is licensed under the MIT License.
Make sure to replace placeholders like 'tulsi-halwai' with your actual GitHub username and update any other details specific to your project. This README provides an overview of the project, installation instructions, usage guide, information about API endpoints and data files, contribution guidelines, and license information.
Having a well-documented README.md file makes it easier for others to understand, use, and contribute to your project.
