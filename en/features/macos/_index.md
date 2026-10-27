---
title: Run Slides on macOS
description: Use the Slides library in supported macOS application environments.
type: docs
url: /features/macos/
weight: 1630
feature_id: macos
feature_group: runtime
translationKey: slides-feature-macos
feature_catalogue_version: 3
feature_guides:
- /slides/net/system-requirements/
---

## **Overview**

Set up the library and its runtime dependencies on macOS for presentation development or processing. Follow the system requirements for the selected binding and package, including architecture and font requirements. Use the same presentation workflows described in that binding's guides.

## **Usage example**

This C# example requires a supported macOS .NET runtime, the matching macOS cross-platform graphics library and available fonts. It prints the operating system and process architecture, then writes runtime.pptx, runtime.pdf and runtime.png. Select the Intel or Apple-silicon package for the process that runs the application. No input presentation is needed.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Runtime.InteropServices;

Console.WriteLine($"OS: {RuntimeInformation.OSDescription}; process: {RuntimeInformation.ProcessArchitecture}");
using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 60, 60, 540, 100);
shape.Name = "Runtime marker";
shape.TextFrame.Text = "macOS rendering";
presentation.Save("runtime.pptx", SaveFormat.Pptx);
presentation.Save("runtime.pdf", SaveFormat.Pdf);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("runtime.png", ImageFormat.Png);
```

## **FAQ**

### **Should I choose requirements by operating system alone?**

Choose by both the operating system and the library binding. The required runtime and native dependencies depend on the package you use.

### **Should the application and its native libraries use the same processor architecture?**

Yes. Match the process architecture to the native graphics library, including when an application runs through an architecture translation layer. Check the selected package rather than assuming the machine model determines the process architecture.

### **How do I provide additional fonts to a macOS application?**

Install the fonts for the service account or load a local application font folder before opening presentations. Verify the required glyphs and rendered layout in that macOS environment.

## **Guides**

- [System Requirements (.NET)](/slides/net/system-requirements/)

Related feature: [Load fonts from a folder](/slides/features/custom-fonts/).
