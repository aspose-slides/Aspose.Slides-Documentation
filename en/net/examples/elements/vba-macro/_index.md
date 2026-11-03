---
title: VBA Macro
type: docs
weight: 150
url: /net/examples/elements/vba-macro/
keywords:
- VBA macro
- add VBA macro
- access VBA macro
- remove VBA macro
- code example
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Automate presentations with Aspose.Slides for .NET: create, run, import, and secure VBA macros in PPT, PPTX, and ODP using clear C# examples."
---

This article demonstrates how to add, access, and remove VBA macros using **Aspose.Slides for .NET**.

The checks verify VBA source and macro-enabled presentation storage. Executing VBA requires a compatible application and its macro security permissions.

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

## **Add a VBA Macro**

Create a presentation with a VBA project and a simple macro module.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;
using Aspose.Slides.Vba;

using var presentation = new Presentation();
presentation.VbaProject = new VbaProject();

var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

presentation.Save("vba-macro-01.pptm", SaveFormat.Pptm);
```

## **Access a VBA Macro**

Retrieve the first module from the VBA project.

```csharp
using System;
using Aspose.Slides.Export;
using Aspose.Slides;
using Aspose.Slides.Vba;

using var presentation = new Presentation();
presentation.VbaProject = new VbaProject();

var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

var firstModule = presentation.VbaProject.Modules[0];
Console.WriteLine(firstModule.Name);

presentation.Save("vba-macro-02.pptm", SaveFormat.Pptm);
```

## **Remove a VBA Macro**

Delete a module from the VBA project.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;
using Aspose.Slides.Vba;

using var presentation = new Presentation();
presentation.VbaProject = new VbaProject();

var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

presentation.VbaProject.Modules.Remove(module);

presentation.Save("vba-macro-03.pptm", SaveFormat.Pptm);
```
