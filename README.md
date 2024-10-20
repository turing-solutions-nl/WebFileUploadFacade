# WebFileUploadFacade

[![publish](https://github.com/turing-solutions-nl/WebFileUploadFacade/actions/workflows/publish-nuget.yml/badge.svg)](https://github.com/turing-solutions-nl/WebFileUploadFacade/actions/workflows/publish-nuget.yml)

This repository serves as a facade to simplify file uploads, offering an easy-to-use interface for uploading files to various sources. It is distributed as a C# NuGet package, designed for seamless integration into your projects.

## Features

- Simplified **file upload interface**;
- Image resizing (width and height in pixels) while keeping the correct aspect ratio;
- Easily extendable to support multiple storage providers;
- Seamless integration into C# projects via NuGet.

## Supported File Upload Strategies

| Strategy                        | Description                                                                 |
|----------------------------------|-----------------------------------------------------------------------------|
| Azure Storage Account Container  | Upload files directly to an Azure Storage Account container.                 |

_Note: More file upload strategies will be supported in the future._

## Installation

To install the package, add the **WebFileUploadFacade** NuGet package to your project using the following command:

```bash
dotnet add package WebFileUploadFacade
```

## Service registration
### Azure Storage Account Container
To configure your project to use Azure Blob Storage for file uploads, add the following code to your Program.cs file:

```C#
// Resolve the interface IFileUploadHandler as AzureBlobStorageFileUpload
builder.Services.AddScoped<IFileUploadHandler, AzureBlobStorageFileUpload>();
```

```C#
// Register the BlobServiceClient (Azure NuGet package) with the connection string of your Azure Storage Account
var storageConnectionString = builder.Configuration.GetConnectionString("StorageAccountConnectionString");
builder.Services.AddSingleton(x =>
    new BlobServiceClient(storageConnectionString));
```
