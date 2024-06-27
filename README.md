# Contact Manager MVC Web App

This is a Contact Manager MVC Web Application built using .NET 8, Entity Framework Core, Microsoft SQL Server, jQuery, and Bootstrap. It allows users to create, view, edit, delete, and search for contacts, as well as view their addresses on a map.

## Table of Contents

- [Features](#features)
- [Tech Stack](#tech-stack)
- [Setup Instructions](#setup-instructions)
- [Usage](#usage)
- [Validation](#validation)
- [Map Integration](#map-integration)
- [Unit Tests](#unit-tests)
- [License](#license)

## Features

- Display a list of all contacts with search functionality.
- Create new contacts.
- View and edit existing contacts.
- Delete contacts with confirmation.
- Optionally add a contact’s address and view it on a map.
- Client-side and server-side validation.

## Tech Stack

- Microsoft .NET 8 MVC Web Application
- Entity Framework Core
- Microsoft SQL Server
- jQuery
- Bootstrap

## Setup Instructions

1. **Clone the repository:**

   ```sh
   git clone https://github.com/yourusername/ContactManager.git
   cd ContactManager


Install dependencies:


2. **dotnet restore:**
dotnet restore

2. **Apply migrations and seed the database:**

dotnet ef migrations add InitialCreate
dotnet ef database update
Run the application:

