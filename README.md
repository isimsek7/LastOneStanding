# Last One Standing API

This API is designed to manage competitors and categories for a competition-based system. It provides full CRUD (Create, Read, Update, Delete) functionality for both `Competitors` and `Categories`.

## Features

- **Competitors**: Manage competitors with their associated categories.
- **Categories**: Manage categories with a list of competitors in each category.
- Efficient data retrieval using Entity Framework Core.
- RESTful API design with endpoints for CRUD operations.

## Technologies

- **.NET Core**: The API is built using ASP.NET Core.
- **Entity Framework Core**: Used for database interactions.
- **SQL Server**: The database system.
- **C#**: The primary language used in the API.

## API Endpoints

### Competitors

- `GET /api/competitors`  
  Retrieves all competitors, including their category names.
  
- `GET /api/competitors/{id}`  
  Retrieves a competitor by its ID.
  
- `POST /api/competitors`  
  Creates a new competitor.
  
- `PUT /api/competitors/{id}`  
  Updates an existing competitor.
  
- `DELETE /api/competitors/{id}`  
  Deletes a competitor.

### Categories

- `GET /api/categories`  
  Retrieves all categories, including a list of competitors (full names).
  
- `GET /api/categories/{id}`  
  Retrieves a category by its ID.
  
- `DELETE /api/categories/{id}`  
  Deletes a category.

## Database Model

The database has two main entities:

- **Competitors**: Includes properties like `FirstName`, `LastName`, `CategoryId`, and a navigation property to the `Category`.
  
- **Category**: Includes properties like `CategoryType` (enum), and a list of `Competitors` associated with the category.

## Setup Instructions

1. Clone the repository:  
   ```bash
   git clone https://github.com/yourusername/last-one-standing-api.git
