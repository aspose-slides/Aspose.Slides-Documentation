---
title: Run Slides on ARM64
description: Run suitable Slides library packages on supported ARM64 platforms.
type: docs
url: /features/arm64/
weight: 1640
feature_id: arm64
feature_group: runtime
translationKey: slides-feature-arm64
feature_catalogue_version: 3
feature_guides:
- /slides/net/slides-for-net-6-cross-platform-zip-package/
---

## **Overview**

Use an ARM64-compatible package and runtime for presentation processing on supported Linux or macOS systems. Include the native dependencies required by that build. Architecture support is a package and operating-system choice, so use the corresponding deployment guidance.

## **Usage example**

This C# example uses the ARM64 build of the .NET cross-platform package and its matching native graphics library. On supported Linux ARM64, supply the documented glibc and fontconfig dependencies; macOS has its own ARM64 library. The program prints the actual process architecture and saves runtime.pptx, runtime.pdf and runtime.png. It needs a genuine ARM64 runtime, including a correctly configured emulated runtime, and suitable fonts; an x64 run does not validate this setup. No input presentation is needed.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Runtime.InteropServices;

Console.WriteLine($"OS: {RuntimeInformation.OSDescription}; process: {RuntimeInformation.ProcessArchitecture}");
using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 60, 60, 540, 100);
shape.Name = "Runtime marker";
shape.TextFrame.Text = "ARM64 rendering";
presentation.Save("runtime.pptx", SaveFormat.Pptx);
presentation.Save("runtime.pdf", SaveFormat.Pdf);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("runtime.png", ImageFormat.Png);
```

## **FAQ**

### **Does ARM64 support imply the same setup on every operating system?**

No. Follow the platform list for the selected package; Linux or macOS ARM64 coverage does not imply Windows ARM support.

### **What can indicate that an x64 native dependency was deployed to an ARM64 process?**

Native-library load errors, an incompatible-image error or a reported x64 process can indicate an architecture mismatch. Check both the running process and the native dependency selected for the deployment.

### **Does ARM64 support mean every language binding has the same package?**

No. Check the actual binding and operating-system package. ARM64 support for a particular .NET cross-platform build does not establish the same package layout or coverage for every other binding.

## **Guides**

- [Aspose.Slides for .NET 6 Cross-Platform (ZIP Package)](/slides/net/slides-for-net-6-cross-platform-zip-package/)

Related feature: [Choose a .NET runtime](/slides/features/dotnet-runtimes/).
