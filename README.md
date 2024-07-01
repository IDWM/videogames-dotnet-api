# VideoGame API REST

This project is an ASP.NET Core 8 application that provides a CRUD (Create, Read, Update, Delete) interface for managing video games, including the ability to upload images using Cloudinary.

## Prerequisites

Before you begin, ensure you have the following installed:

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Postman](https://www.postman.com/downloads/)

## Clone the Project

```bash
git clone https://github.com/IDWM/videogames-dotnet-api.git
```

## Create the appsettings File

Create a file named `appsettings.json` in the project root and paste the following content:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data source=videogames.db"
  },
  "CloudinarySettings": {
    "CloudName": "your_cloud_name",
    "ApiKey": "your_api_key",
    "ApiSecret": "your_api_secret"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

## Configure Cloudinary Credentials

1. Create an account on [Cloudinary](https://cloudinary.com/).
2. Replace `your_cloud_name`, `your_api_key`, and `your_api_secret` in the `CloudinarySettings` section with your actual Cloudinary credentials.

## Install .NET Dependencies

Navigate to the project directory and execute the following command to install .NET dependencies:

```bash
dotnet restore
```

## Run the Project

Execute the following command to start the project:

```bash
dotnet run
```

The application will be available at `http://localhost:5000`.

## Postman Collection

A Postman collection is provided to facilitate testing the API endpoints. You can find the collection file in the project's root directory.
