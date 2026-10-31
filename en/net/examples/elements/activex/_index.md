---
title: ActiveX
type: docs
weight: 200
url: /net/examples/elements/activex/
keywords:
- ActiveX
- add ActiveX
- access ActiveX
- remove ActiveX
- ActiveX properties
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "See Aspose.Slides for .NET ActiveX examples: insert, configure, and control ActiveX objects in PPT and PPTX presentations with clear C# code."
---

This article demonstrates how to add, access, remove, and configure ActiveX controls in a presentation using **Aspose.Slides for .NET**.

The checks verify stored controls and properties. Opening or executing ActiveX controls requires a compatible Windows host and its security permissions.

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

Each printed `CaseNN.cs` file is compiled verbatim with the included `Program.cs` and bootstrap. Checks run before saving and after reopening the result.

## **Add an ActiveX Control**

Insert a new ActiveX control and optionally set its properties.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        // Add a new ActiveX control.
        var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        // Optionally set some properties.
        control.Properties["Value"] = "Text";

        presentation.Save("add_activex.pptm", SaveFormat.Pptm);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-001", p =>
        {
            Context.Require(p.Slides[0].Controls.Count == 1 && p.Slides[0].Controls[0].Properties["Value"] == "Text", "AddActiveX: semantic check 1 failed.");
        }, SaveFormat.Pptm);
        Context.Pass("elements/activex/block-001", "AddActiveX", "save-reopen-structure");
    }
}
```

## **Access an ActiveX Control**

Read information from the first ActiveX control on the slide.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation(Seed("control"));
        var slide = presentation.Slides[0];

        // Access the first ActiveX control.
        var control = slide.Controls.FirstOrDefault();
        if (control != null)
        {
            Console.WriteLine($"Control Name: {control.Name}");
            Console.WriteLine($"Value: {control.Properties["Value"]}");
        }

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-002", p =>
        {
            Context.Require(p.Slides[0].Controls.Count == 1 && p.Slides[0].Controls[0].Properties["Value"] == "Text", "AccessActiveX: semantic check 1 failed.");
        }, SaveFormat.Pptm);
        Context.Pass("elements/activex/block-002", "AccessActiveX", "save-reopen-structure");
    }
}
```

## **Remove an ActiveX Control**

Delete an existing ActiveX control from the slide.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case03()
    {
        using var presentation = new Presentation(Seed("control"));
        var slide = presentation.Slides[0];

        if (slide.Controls.Count > 0)
        {
            // Remove the first ActiveX control.
            slide.Controls.RemoveAt(0);
        }

        presentation.Save("removed_activex.pptm", SaveFormat.Pptm);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-003", p =>
        {
            Context.Require(p.Slides[0].Controls.Count == 0, "RemoveActiveX: semantic check 1 failed.");
        }, SaveFormat.Pptm);
        Context.Pass("elements/activex/block-003", "RemoveActiveX", "save-reopen-structure");
    }
}
```

## **Set ActiveX Properties**

Add a control and configure several ActiveX properties.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        // Add a CommandButton and configure properties.
        var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
        control.Properties["Caption"] = "Run";
        control.Properties["Enabled"] = "true";

        presentation.Save("set_activex_props.pptm", SaveFormat.Pptm);

        // Validate the in-memory operation and its persisted result independently.
        RoundTrip(presentation, "block-004", p =>
        {
            Context.Require(p.Slides[0].Controls.Count == 1 && p.Slides[0].Controls[0].Properties["Caption"] == "Run" && p.Slides[0].Controls[0].Properties["Enabled"] == "true", "SetActiveXProperties: semantic check 1 failed.");
        }, SaveFormat.Pptm);
        Context.Pass("elements/activex/block-004", "SetActiveXProperties", "save-reopen-structure");
    }
}
```
