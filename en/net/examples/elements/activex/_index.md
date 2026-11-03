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

Each printed `CaseNN.cs` file is compiled verbatim. The download checks each case in `CaseVerification.cs` before saving and after reopening the result.

## **Add an ActiveX Control**

Insert a new ActiveX control and optionally set its properties.

```csharp
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

        VerifyCase01(presentation);
    }
}
```

## **Access an ActiveX Control**

Read information from the first ActiveX control on the slide.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

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

        VerifyCase02(presentation);
    }
}
```

## **Remove an ActiveX Control**

Delete an existing ActiveX control from the slide.

```csharp
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

        VerifyCase03(presentation);
    }
}
```

## **Set ActiveX Properties**

Add a control and configure several ActiveX properties.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

internal static partial class Program
{
    static void Case04()
    {
        using var presentation = new Presentation();
        var slide = presentation.Slides[0];

        // Add a Windows Media Player control and configure its properties.
        var control = slide.Controls.AddControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
        control.Properties["Caption"] = "Run";
        control.Properties["Enabled"] = "true";

        presentation.Save("set_activex_props.pptm", SaveFormat.Pptm);

        VerifyCase04(presentation);
    }
}
```
