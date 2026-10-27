---
title: Use Slides from .NET
description: Use the Slides library directly from a .NET application.
type: docs
url: /features/dotnet-api/
weight: 350
feature_id: dotnet-api
feature_group: languages
translationKey: slides-feature-dotnet-api
feature_catalogue_version: 3
feature_guides:
- /slides/net/installation/
---

## **Overview**

Add the Slides .NET package to an application to create, edit, convert and render presentations through in-process API calls. Use the .NET guides for installation, presentation objects and export options, and choose a package suited to the runtime and operating system you deploy on.

## **Usage example**

This C# example uses Aspose.Slides for .NET. Add the package to a console project as described in the [installation guide](/slides/net/installation/). It creates one slide with a text box, saves *hello.pptx* in the working directory and prints a confirmation. No input presentation is needed.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var title = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
title.TextFrame.Text = "Hello from .NET";
presentation.Save("hello.pptx", SaveFormat.Pptx);
Console.WriteLine("Saved hello.pptx");
```

The rectangle is positioned 50 points from the left and top edges and measures 400 by 100 points. Without a license, the saved slide also carries an evaluation watermark.

## **FAQ**

### **Do I need a separate conversion server?**

No. The library runs inside your application. Your application controls the files, streams and processing jobs.

### **How do I install the .NET package in a project?**

Add the Aspose.Slides NuGet package to the application that will perform the processing, using the [installation steps](/slides/net/installation/). Choose a target framework supported by the package and deploy its required native dependencies.

### **Which namespaces are needed to save a presentation?**

The example imports Aspose.Slides for the presentation model and Aspose.Slides.Export for output formats. System supplies its console output. Keep the imports at the top of the source file.

## **Guides**

- [Installation (.NET)](/slides/net/installation/)

Related feature: [Choose a .NET runtime](/slides/features/dotnet-runtimes/).
