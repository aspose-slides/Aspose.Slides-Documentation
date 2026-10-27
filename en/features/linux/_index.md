---
title: Run Slides on Linux
description: Run presentation creation, editing and rendering on Linux.
type: docs
url: /features/linux/
weight: 1620
feature_id: linux
feature_group: runtime
translationKey: slides-feature-linux
feature_catalogue_version: 3
feature_guides:
- /slides/net/slides-for-net-6-cross-platform-zip-package/
---

## **Overview**

Deploy a suitable Slides library package with the native dependencies and fonts required by your Linux application. This supports server and container workflows without a desktop Office installation. Rendering dependencies vary by package, so use the platform-specific setup guidance.

## **Usage example**

This C# example creates runtime.pptx, runtime.pdf and runtime.png with Aspose.Slides for .NET on Linux and prints the operating system and process architecture. It uses the standard package with its documented Unix support switch, libgdiplus and installed fonts. Install these prerequisites before running; this example does not install them. The cross-platform package instead uses its own native graphics library and fontconfig. No input presentation is needed.

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
shape.TextFrame.Text = "Linux rendering";
presentation.Save("runtime.pptx", SaveFormat.Pptx);
presentation.Save("runtime.pdf", SaveFormat.Pdf);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("runtime.png", ImageFormat.Png);
```

## **FAQ**

### **Do the standard and cross-platform .NET builds use identical graphics dependencies?**

No. Their dependency requirements differ. Follow the instructions for the build actually included in the application.

### **Which temporary-directory permissions does a Linux worker need?**

Give the worker account permission to create and remove files in its temporary directory, and to write results to the output directory. Use a suitable writable mount when the container filesystem is restricted.

### **How should I provide fonts on a Linux host?**

Install fonts in the Linux image or load a local application font folder before processing. Check character coverage and actual rendered output; a headless host may start with very few fonts.

## **Guides**

- [Aspose.Slides for .NET 6 Cross-Platform (ZIP Package)](/slides/net/slides-for-net-6-cross-platform-zip-package/)

Related feature: [Run Slides in Docker containers](/slides/features/docker/).
