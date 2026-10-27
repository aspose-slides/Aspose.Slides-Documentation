---
title: Install and license Slides on an isolated network
description: Install the library and apply a file license without internet access.
type: docs
url: /features/air-gapped-installation/
weight: 1660
feature_id: air-gapped-installation
feature_group: runtime
translationKey: slides-feature-air-gapped-installation
feature_catalogue_version: 3
feature_guides:
- /slides/net/licensing/
---

## **Overview**

Prepare the library packages, runtime dependencies, fonts and license file for an isolated environment. File-based licensing is checked locally, so normal presentation processing can run without contacting a licensing service. Keep all required resources accessible within the environment.

## **Usage example**

Prepare an existing .NET 8 console project named PresentationApp.csproj that references the standard Aspose.Slides for .NET package, and use the following complete C# source as Program.cs. On a connected machine, collect the project's NuGet packages and every transitive dependency into offline-feed, along with the required runtime, native graphics dependencies and fonts. The second block restores from that local feed and runs without another restore. On Linux this standard-package example needs libgdiplus, fonts and the Unix support switch shown in the source. Run it in the isolated environment after copying those assets. It creates runtime.pptx, runtime.pdf and runtime.png. The example uses evaluation mode; supply your appropriate file-based license separately for licensed processing.

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
shape.TextFrame.Text = "Offline restore rendering";
presentation.Save("runtime.pptx", SaveFormat.Pptx);
presentation.Save("runtime.pdf", SaveFormat.Pdf);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("runtime.png", ImageFormat.Png);
```

```bash
dotnet restore PresentationApp.csproj --source ./offline-feed --packages ./offline-packages --artifacts-path ./artifacts
dotnet build PresentationApp.csproj --no-restore --artifacts-path ./artifacts -p:ImplicitUsings=disable
dotnet ./artifacts/bin/PresentationApp/debug/PresentationApp.dll
```

## **FAQ**

### **Can I use metered licensing on a disconnected machine?**

Metered licensing requires network communication. Use the appropriate file-based license for an offline deployment, and keep optional AI endpoint requirements separate.

### **Which dependencies must I copy before isolating the machine?**

Copy the selected package and all transitive packages, the runtime, native graphics dependencies, fonts, input assets and any appropriate file-based license. Prepare the actual target operating system and architecture, rather than copying only the main DLL.

### **How can I verify that a local package feed contains transitive dependencies before isolation?**

Restore into a fresh package directory using only the prepared feed, with networking disabled, then run a representative rendering operation. A warm package cache can hide missing transitive packages; the commands below use a separate package directory.

## **Guides**

- [Licensing (.NET)](/slides/net/licensing/)

Related feature: [Process presentations without internet access](/slides/features/offline-processing/).
