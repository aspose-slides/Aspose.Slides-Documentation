---
title: Use the Slides library in Azure Functions
description: Process presentations with the local Slides library inside Azure Functions.
type: docs
url: /features/azure-functions/
weight: 1650
feature_id: azure-functions
feature_group: runtime
translationKey: slides-feature-azure-functions
feature_catalogue_version: 3
feature_guides:
- /slides/net/using-aspose-slides-on-azure/
---

## **Overview**

Include the Slides library in an Azure Functions application and run presentation processing when a function is triggered. For example, a storage-triggered function can read a presentation and write an exported result. You manage the function, its dependencies and its storage workflow.

## **Usage example**

Add this complete C# function file to an existing .NET isolated Azure Functions project with the HTTP extension and Aspose.Slides for .NET installed. Follow Microsoft's [local development setup](https://learn.microsoft.com/en-us/azure/azure-functions/functions-develop-local) for the Functions host and project. Start the local host, then request /api/presentation.pdf on its localhost port. The HTTP trigger creates a one-slide PDF containing Local function rendering and returns application/pdf. It needs the selected package's fonts and native dependencies. This example tests a local Functions invocation; deploying to Azure requires the matching hosting setup and is a separate step.

```csharp
using System.IO;
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

public class PresentationFunction
{
    [Function("CreatePresentationPdf")]
    public HttpResponseData Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "presentation.pdf")] HttpRequestData request)
    {
        using var presentation = new Presentation();
        var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 60, 60, 540, 100);
        shape.TextFrame.Text = "Local function rendering";
        using var output = new MemoryStream();
        presentation.Save(output, SaveFormat.Pdf);
        var response = request.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "application/pdf");
        var bytes = output.ToArray();
        response.Body.Write(bytes, 0, bytes.Length);
        return response;
    }
}
```

## **FAQ**

### **Is this the hosted Slides Cloud API?**

No. The installed library runs inside your Azure Function. Its runtime, fonts and temporary storage are part of your function deployment.

### **Where should I store fonts and temporary files in a function app?**

Package fonts with the app or load them from a readable application directory. Use the host's writable temporary location for transient work and durable storage for outputs that must survive the invocation.

### **How should I dispose presentation resources after an invocation?**

Scope the presentation and its streams to the invocation and dispose them after conversion, as shown. Do not keep presentation objects in shared static state across invocations.

## **Guides**

- [Using Aspose.Slides on Azure (.NET)](/slides/net/using-aspose-slides-on-azure/)

Related feature: [Run Slides on your own servers](/slides/features/run-on-own-servers/).
