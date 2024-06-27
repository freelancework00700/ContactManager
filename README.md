Contact Manager MVC Web App
This is a Contact Manager MVC Web Application built using .NET 8, Entity Framework Core, Microsoft SQL Server, jQuery, and Bootstrap. It allows users to create, view, edit, delete, and search for contacts, as well as view their addresses on a map.

Table of Contents
Features
Tech Stack
Setup Instructions
Usage
Validation
Map Integration
Unit Tests
License
Features
Display a list of all contacts with search functionality.
Create new contacts.
View and edit existing contacts.
Delete contacts with confirmation.
Optionally add a contact’s address and view it on a map.
Client-side and server-side validation.
Tech Stack
Microsoft .NET 8 MVC Web Application
Entity Framework Core
Microsoft SQL Server
jQuery
Bootstrap
Setup Instructions
Clone the repository:

sh
Copy code
git clone https://github.com/yourusername/ContactManager.git
cd ContactManager
Configure the connection string:

Update the appsettings.json file with your SQL Server connection string.

json
Copy code
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ContactManagerDb;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
Install dependencies:

sh
Copy code
dotnet restore
Apply migrations and seed the database:

sh
Copy code
dotnet ef migrations add InitialCreate
dotnet ef database update
Run the application:

sh
Copy code
dotnet run
Open your browser and navigate to:

arduino
Copy code
https://localhost:5001
Usage
Create a Contact
Click on the "Create New" button.
Fill in the contact details and click "Create".
Edit a Contact
Click on the "Edit" button next to a contact.
Update the contact details and click "Save".
Delete a Contact
Click on the "Delete" button next to a contact.
Confirm the deletion.
View Contact Details
Click on the "View" button next to a contact to see the details in a popup.
Validation
Client-side and server-side validation is implemented to ensure data integrity.

Client-side validation: Implemented using jQuery Validation and Unobtrusive Validation.
Server-side validation: Implemented using Data Annotations in the Contact model.
Map Integration
To view a contact’s address on a map, ensure you have a valid Google Maps API key.

Replace YOUR_API_KEY in _Layout.cshtml and Edit.cshtml with your actual Google Maps API key.

html
Copy code
<script src="https://maps.googleapis.com/maps/api/js?key=YOUR_API_KEY&callback=initMap" async defer></script>
When editing a contact with an address, the map will display the location based on the address provided.

Unit Tests
Unit tests are included to validate key functionalities.

Create a Unit Test Project:

sh
Copy code
dotnet new xunit -n ContactManager.Tests
cd ContactManager.Tests
dotnet add reference ../ContactManager/ContactManager.csproj
Run the tests:

sh
Copy code
dotnet test
License
This project is licensed under the MIT License.
