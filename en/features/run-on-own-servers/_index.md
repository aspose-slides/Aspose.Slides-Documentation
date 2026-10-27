---
title: Run Slides on your own servers
description: Process presentations inside your own application and infrastructure.
type: docs
url: /features/run-on-own-servers/
weight: 310
feature_id: run-on-own-servers
feature_group: deployment
translationKey: slides-feature-run-on-own-servers
feature_catalogue_version: 3
feature_guides:
- /slides/net/installation/
---

## **Overview**

Install the Slides library on a workstation or server and process presentations there. Your application opens local files or streams and writes the results to storage you control. Standard presentation creation, editing and rendering do not require a hosted conversion service.

## **Usage example**

This C# example runs the installed .NET library inside your application process. It creates a one-slide presentation and writes runtime.pptx, runtime.pdf and runtime.png in a writable working directory; no input file or hosted conversion service is needed. Install the runtime, graphics dependencies and fonts for the selected package using the [installation guide](/slides/net/installation/). The Unix support switch applies to the standard .NET package when running it on Linux; the cross-platform package has different dependencies.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Runtime.InteropServices;

AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
Console.WriteLine($"OS: {RuntimeInformation.OSDescription}; process: {RuntimeInformation.ProcessArchitecture}");
using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 60, 60, 540, 100);
shape.Name = "Runtime marker";
shape.TextFrame.Text = "Own server rendering";
presentation.Save("runtime.pptx", SaveFormat.Pptx);
presentation.Save("runtime.pdf", SaveFormat.Pdf);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("runtime.png", ImageFormat.Png);
```

## **FAQ**

### **Must I upload presentations to a vendor service?**

No. Ordinary library processing runs locally. Optional AI methods use the model endpoint configured for that separate workflow.

### **Which dependencies must be deployed with a server app?**

Deploy the selected library package, its .NET runtime, required native graphics libraries and the fonts used by the documents. Also provide writable temporary and output storage; a managed assembly alone does not establish a complete server installation.

### **How should I provide fonts on a headless server?**

Install the required fonts in the image or host, or load a controlled application font folder before processing. Include glyph coverage for the input languages and test the rendered output under the actual service account.

## **Guides**

- [Installation (.NET)](/slides/net/installation/)

Related feature: [Process presentations without internet access](/slides/features/offline-processing/).
