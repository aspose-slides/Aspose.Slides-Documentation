---
title: Integrating Aspose.Slides with Google Slides
linktitle: Google Slides
type: docs
weight: 50
url: /net/integrating-aspose-slides-with-google-slides/
keywords:
- cloud platforms
- cloud integration
- Google Slides
- Google Drive
- Google API
- Google Service Account
- SaaS integration
- OAuth 2.0
- PPT to PDF
- PowerPoint automation
- presentation processing
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Connect Aspose.Slides with Google Slides to import, sync, and convert presentations, automate workflows, and keep PowerPoint and OpenDocument in one pipeline."
---

## **Introduction**

Aspose.Slides now provides integration with Google Slides and Google Drive through its [SaaS Integration API](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations). This integration enables .NET apps to convert, edit, download, and upload Google Slides presentations.

## **What Is Google Slides?**
[Google Slides](https://workspace.google.com/products/slides/) is a free, web-based presentation software developed by Google. It lets users create, edit, and share slide presentations online, similar to Microsoft PowerPoint. It supports real-time collaboration, cloud storage, and works on any device with internet access.

## **Google API**
Before starting to work with your Google Slides presentation via Aspose.Slides you have to create a Google API project and  create a [Google Cloud project](https://developers.google.com/workspace/guides/create-project), then enable the desired APIs. 

Then you have to choose a way you are going to access Google API - [Aspose.SlideS Google Integration](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) supports two ways to access Google API: 
- `Google Service Account`
- `OAuth 2.0` with user interaction via a browser.

### **Google Service Account**
A service account is a special Google account used by applications or servers to access Google APIs programmatically without user interaction. It’s commonly used for backend systems or automated tasks. Service accounts are authenticated using a JSON key file and have their own email address. They can be assigned specific permissions through [Google Cloud IAM](https://cloud.google.com/iam/docs/overview) and are often used with APIs like Google Drive, Sheets, or BigQuery for secure, automated access to resources.

### **OAuth 2.0**
Another common way to access Google APIs is through OAuth 2.0 with user interaction via a browser. In this flow, the user is redirected to a Google sign-in page where they grant permission to the app. After approval, the app receives an authorization code, which it exchanges for an access token and a refresh token.

The access token allows temporary access to Google APIs, while the refresh token can be stored and reused to obtain new access tokens without requiring the user to log in again. This means browser interaction is required only once, making subsequent API access fully automated. This method is typically used for apps that need to access a user's data (like Gmail, Calendar, or Drive) with the user's consent.

## **Let's Code**
First, add the [Aspose.Slides SaaS Integration NuGet package](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) to your project:

```
dotnet add package Aspose.Slides.SaaSIntegrations
```

### **Example 1**
In the following example, we will download a Google Slides presentation from Google Drive and save it to the local disk as a PDF file. We will use a Google Service Account for authorization, assuming the service account JSON file with credentials has already been downloaded.

```csharp
// Create externally managed HttpClient
HttpClient httpClient = new HttpClient();

// Create an authorization provider using a service account JSON file
IGoogleAuthorizationProvider account = new GoogleServiceAccountAuthProvider(@"service_account_json_file.json", httpClient);

// Initialize Google Slides integration service with the authorization provider
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// Load a presentation from Google Drive by its file ID into an Aspose.Slides IPresentation instance
using IPresentation pres = await googleSlidesIntegration.LoadPresentationAsync("1A2B3C4D5E6F7G8H9I0J");

// Modify the presentation if needed (e.g., remove the second slide)
pres.Slides.RemoveAt(1);

// Save the presentation locally as a PDF file
pres.Save(@"GoogleDriveDownload.pdf", SaveFormat.Pdf);
```

For convenience, Aspose.Slides SaaS Integration provides a method to list all files available to the user. The returned data includes the file name, MIME type, and file ID.

```csharp
// Get the list of files available to the provided service account
var availableFiles = await googleSlidesIntegration.GetDriveFileInfosAsync();

foreach (GoogleDriveFileInfo googleDriveFileInfo in availableFiles)
{
    Console.WriteLine($"File name: {googleDriveFileInfo.Name}, File ID: {googleDriveFileInfo.Id}, MIME type: {googleDriveFileInfo.MimeType}");
}
```

Another way to find the file ID is to open the presentation in the Google Slides web app and locate it in the URL.

For example, in the following URL:

```
https://docs.google.com/presentation/d/1A2B3C4D5E6F7G8H9I0J/edit
```

The file ID is:

```
1A2B3C4D5E6F7G8H9I0J
```

## **Example 2**
In the next example, we will create a PowerPoint presentation from scratch and upload it to Google Drive in Google Slides format. For authorization, we will use OAuth 2.0.

```csharp
// Create externally managed HttpClient
HttpClient httpClient = new HttpClient();

// Create an authorization provider using OAuth with client ID and client secret
IGoogleAuthorizationProvider account = new GoogleOAuthProvider("clientId", "clientSecret", httpClient);

// Initialize the Google Slides integration service with the authorization provider
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// Create a sample presentation
using (var presentation = new Presentation())
{
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";
    
    // Save the presentation to Google Drive root folder in Google Slides format
    // You can also choose any other export format supported by Aspose.Slides
    var newFileId = await googleSlidesIntegration.SavePresentationAsync(presentation, "New presentation", GoogleSaveFormatType.GoogleSlides);
    Console.WriteLine($"Uploaded file ID: {newFileId}");
}

```

If you use this type of authorization in your app, `interaction with the browser is required`. You will need to select your account and confirm that you allow the app to access your Google Drive API. That’s it—this operation is only required on the first run.

### **Example 3**
In the following example we will use preobtained access token. `GoogleAccessTokenAuthProvider` is an implementation of the `IGoogleAuthorizationProvider` interface that uses an existing OAuth 2.0 access token to authorize requests to Google APIs. Unlike providers that initiate or manage the OAuth flow, this class relies on the caller to supply a valid access token.

This provider is useful in systems where the access token is obtained externally—typically by a frontend application or another service—and passed to the backend. It is especially suitable for distributed environments where managing refresh tokens server-side introduces complexity or risk of token invalidation due to concurrent refresh attempts.

This example demonstrates how to replace a file and update its name on Google Drive while preserving its file ID.

```csharp
// Create an HTTP client for making requests
using HttpClient httpClient = new HttpClient();

// Set up Google Drive authentication using an access token
GoogleAccessTokenAuthProvider accessTokenAuthProvider = new GoogleAccessTokenAuthProvider("access_token");

// Initialize integration with Google Slides/Drive using the authentication and HTTP client
GoogleSlidesIntegration googleSlidesIntegration =
    new GoogleSlidesIntegration(accessTokenAuthProvider, httpClient);

// Create a sample presentation using Aspose.Slides
using (var presentation = new Presentation())
{
    // Add a rectangle shape to the first slide and set its text
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";

    // Define PDF save options with specific quality and compliance settings
    ISaveOptions saveOptions = new PdfOptions()
    {
        JpegQuality = 50,
        Compliance = PdfCompliance.PdfA1b
    };

    // Save (replace) the existing file on Google Drive by file ID, update its name, and export as PDF
    await googleSlidesIntegration.SavePresentationToExistingFileAsync(
        presentation,
        "1A2B3C4D5E6F7G8H9I0J",            // ID of the existing file on Google Drive
        GoogleSaveFormatType.Pdf,         // Desired format to save as
        saveOptions,           
        "NewFileName.pdf"                 // New name to assign to the file
    );
}
```


## **Summary**
Aspose.Slides now supports an additional file format for management, simplifying the automation of cloud-based workflows for creating, sharing, and editing presentations.

This article covered the basic features. You can also save files to subfolders, replace existing files, and export to Google Drive in various formats—not limited to Google Slides presentations.

Aspose.Slides SaaS Integration will continue to expand support for presentation SaaS platforms, so check back for future updates.

## **FAQ**

**Do I need a Google Workspace account to use this integration?**
No. You can use either a free Google account or a Google Workspace account. The required access depends on your Google Drive and Slides permissions.

**Which authentication method should I choose—Service Account or OAuth 2.0?**
Use a **Service Account** for backend or automated workflows without user interaction.
Use **OAuth 2.0** if you need to access a specific user's Google Slides or Drive files with their consent.

**Can I work with formats other than Google Slides?**
Yes. Aspose.Slides allows saving presentations to various formats (e.g., PDF, PPTX, HTML) before uploading them to Google Drive.

**How can I get the file ID of a Google Slides presentation?**
You can retrieve it using the `GetDriveFileInfosAsync()` method or by copying it from the presentation's URL in Google Slides.

**Does the integration support replacing an existing file on Google Drive?**
Yes. Use the `SavePresentationToExistingFileAsync` method to update a file while preserving its file ID.

**Is browser interaction required every time when using OAuth 2.0?**
No. Browser interaction is required only during the first authorization. After that, stored refresh tokens allow automated access.