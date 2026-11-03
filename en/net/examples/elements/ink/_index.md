---
title: Ink
type: docs
weight: 180
url: /net/examples/elements/ink/
keywords:
- ink
- access ink
- remove ink
- code example
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Set and read a tag on an existing ink shape or remove the shape with Aspose.Slides for .NET C# examples."
---

Use **Aspose.Slides for .NET** to set and read tags on an existing ink shape or remove the shape from the slide.

> ❗ **Note:** Ink shapes represent user input from specialized devices. Aspose.Slides cannot create new ink strokes programmatically, but you can read and modify existing ink.

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

Each printed `CaseNN.cs` file is compiled verbatim. The download checks each case in `CaseVerification.cs` before saving and after reopening the result.

<a id="access-ink"></a>

## **Set and Read an Ink Tag**

Set a tag on the first ink shape and read back the known tag value.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Ink;

internal static partial class Program
{
    static void Case01()
    {
        using var presentation = new Presentation(Context.Input("ink.pptx"));
        var slide = presentation.Slides[0];

        var inkShape = slide.Shapes.OfType<Ink>().First();
        inkShape.CustomData.Tags["kind"] = "Ink";
        var tags = inkShape.CustomData.Tags;
        if (tags.Count > 0)
        {
            var tagName = tags.GetNameByIndex(0);
            Context.Require(tags[tagName] == "Ink", "Read the known Ink tag value.");
        }

        VerifyCase01(presentation);
    }
}
```

## **Remove Ink**

Delete an ink shape from the slide if one exists.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Ink;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation(Context.Input("ink.pptx"));
        var slide = presentation.Slides[0];

        if (slide.Shapes.FirstOrDefault(s => s is Ink) is Ink ink)
        {
            slide.Shapes.Remove(ink);
        }

        VerifyCase02(presentation);
    }
}
```
