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

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

Each printed `CaseNN.cs` file is compiled verbatim with the included `Program.cs` and bootstrap. Checks run before saving and after reopening the result.

## **Add a VBA Macro**

Create a presentation with a VBA project and a simple macro module.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        presentation.VbaProject = new VbaProject();

        var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
        module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.VbaProject != null && p.VbaProject.Modules.Count == 1 && p.VbaProject.Modules[0].SourceCode.Contains("Sub Test()"), "AddVbaMacro: semantic check 1 failed.");
        }, SaveFormat.Pptm);
        Context.Pass("elements/vba-macro/block-001", "AddVbaMacro", "save-reopen-structure");
    }
}
```

## **Access a VBA Macro**

Retrieve the first module from the VBA project.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation();
        presentation.VbaProject = new VbaProject();

        var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
        module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

        var firstModule = presentation.VbaProject.Modules[0];

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.VbaProject.Modules[0].Name == "Module" && p.VbaProject.Modules[0].SourceCode.Contains("MsgBox"), "AccessVbaMacro: semantic check 1 failed.");
        }, SaveFormat.Pptm);
        Context.Pass("elements/vba-macro/block-002", "AccessVbaMacro", "save-reopen-structure");
    }
}
```

## **Remove a VBA Macro**

Delete a module from the VBA project.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation();
        presentation.VbaProject = new VbaProject();

        var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
        module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

        presentation.VbaProject.Modules.Remove(module);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(p.VbaProject != null && p.VbaProject.Modules.Count == 0, "RemoveVbaMacro: semantic check 1 failed.");
        }, SaveFormat.Pptm);
        Context.Pass("elements/vba-macro/block-003", "RemoveVbaMacro", "save-reopen-structure");
    }
}
```
